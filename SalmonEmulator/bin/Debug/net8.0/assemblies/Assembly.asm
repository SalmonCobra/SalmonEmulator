; r0-r31
; label:
;
; nop
; halt
; out p, ir
; in p, r
; ldi r, i
; ld r, ar
; st a, ir
; push ir
; pop r
; peek r
; add r, ir
; sub r, ir
; shl r, ir
; shr r, ir
; and r, ir
; or r, ir
; xor r, ir
; not r 
; call
; ret
; cmp r, ir
; jmp 
; jeq
; jne
; jgt
; jge
; jlt
; jle


; ----- EXAMPLE PROGRAM ----- ;

ldi r0, 1
ldi r1, 1

call subroutine
call print

halt

subroutine:
add r0, r1
ret

print:
out 1, r0
ret

; ----- EXAMPLE PROGRAM ----- ;