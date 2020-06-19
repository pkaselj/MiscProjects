$MOD51	; This includes 8051 definitions for the Metalink assembler

STATUS_LED EQU P1.0
OFFSET_UPPER EQU 0AH
OFFSET_LOWER EQU 0FFH
P1M0 EQU 0C2H
P1M1 EQU 0C3H
P3M0 EQU 0C6H
P3M1 EQU 0C7H
SPCR EQU 0D5H
SPSR EQU 0AAH
SPDR EQU 86H
TX EQU P3.0
RX EQU P3.1
CLK EQU P1.7
CS EQU P1.4
MISO EQU P1.6
MOSI EQU P1.5
WAKE_SW EQU P3.4
CM EQU P1.2
INT_REC EQU P3.2
CTS EQU P1.3
	

;=============START=================================

ORG 0000H
	JMP INITIALIZATION

;=============INTERRUPTS============================


ORG 000BH ;TIMER 0 OVERFLOW INTERRUPT
	CLR TR0
	ACALL TIMER0_INTER
	SETB TR0
RETI

;------------------------------------------------

ORG 0023H
RECIEVE_INTERRUPT:
	CLR C
	JNB RI, SKIP_R
SKIP_R:
	CLR RI
RETI

;==============MAIN=================================


ORG 0050H

INITIALIZATION:

	MOV P1M0, #00H
	MOV P1M1, #00H
	MOV P3M0, #00H
	MOV P3M1, #00H


	;set timer offsets
	MOV R6, #OFFSET_LOWER ; TIMER OFFSET LOWER NIBBLE
	MOV R7, #OFFSET_UPPER ; TIMER OFFSET UPPER NIBBLE
	
	;enable interrupts
	SETB EA
	SETB ET0
	SETB ES
	;SETB EX0

	MOV PCON, #00H
	MOV TMOD, #21H
;	MOV TH1, #7EH
;	MOV TH1, #0DFH ;9600 10M
;	MOV TH1, #30H
;	MOV TH1, #64H
	MOV TH1, #0D9H ;9600 12M
	MOV SCON,#50H
	SETB CS

	;Starting the timers
	SETB TR0
	SETB TR1

	JMP IDLE

;------------------------------------------------




;------------------------------------------------

IDLE:
	;SET IDLE MODE
	JMP IDLE
;------------------------------------------------

GET_SPI:
	SETB CLK
	CLR MOSI
	CLR CS
	NOP
	NOP
	NOP
	NOP
	NOP
	
	;read data from first GUVA
	MOV A, #00H
	ACALL SPI
	MOV R2, A

	MOV A, #00H
	ACALL SPI
	MOV R3, A

	;read data from second GUVA
	MOV A, #08H
	ACALL SPI
	MOV R4, A
	
	MOV A, #00H
	ACALL SPI
	MOV R5, A

	NOP
	NOP
	NOP
	NOP
	NOP
	SETB CS
	
	;Format data
	MOV A, #0FH
	ANL A, R2
	
	MOV A,#0F0H
	ANL A, R3
	
	ADD A, R2
	SWAP A
	
	MOV R2, A
	
	MOV A, #0FH
	ANL A, R4
	
	MOV A,#0F0H
	ANL A, R5
	
	ADD A, R4
	SWAP A
	
	MOV R3, A
	
	;Select the greater number
	SUBB A, R2
	JC SEND_R2
	MOV A, R3
	JMP SEND_DATA
	SEND_R2: MOV A, R2
	
	
	;Send data to BLE
	SEND_DATA:
	CLR TI
	MOV SBUF, A
	LOOP0: JNB TI, LOOP0
	CLR TI
	
	;CLR TI
	;MOV SBUF, R2
	;LOOP1: JNB TI, LOOP1
	;CLR TI
	
	;CLR TI
	;MOV SBUF, R3
	;LOOP2: JNB TI, LOOP2
	;CLR TI
	
	;CLR TI
	;MOV SBUF, R4
	;LOOP3: JNB TI, LOOP3
	;CLR TI
	
	;CLR TI
	;MOV SBUF, R5
	;LOOP4: JNB TI, LOOP4
	;CLR TI
RET

;SPI communications function
SPI:
	MOV R1, #08H
	RPT:
	;MOV C, MISO
	CLR CLK
	MOV C, MISO
	RLC A
	MOV MOSI, C
	NOP
	NOP
	SETB CLK
	NOP
	NOP
	NOP
	NOP
	DJNZ R1, RPT
RET

;Timer0 interrupt
TIMER0_INTER:
	DJNZ R6, NOVERFLOW
	MOV R6, #OFFSET_LOWER ; TIMER OFFSET RESET LOWER NIBBLE
	DJNZ R7, NOVERFLOW
	MOV R7, #OFFSET_UPPER ; TIMER OFFSET RESET UPPER NIBBLE
	ACALL GET_SPI
NOVERFLOW:
	CLR TI
RET

;==============END==================================
ENDING:

END