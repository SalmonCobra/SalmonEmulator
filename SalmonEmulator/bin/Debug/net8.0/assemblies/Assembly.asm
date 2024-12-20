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
; mov r, r
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

ldi r1, 1
ldi r2, 2

call multiply
call print


halt

multiply:
    mov r3, r2 ; r3 = the multiple
    mov r4, r2
    mov r2, r1

    multiply_loop:
        cmp r3, 1
        jeq done
        add r1, r2
        sub r3, 1
        jmp multiply_loop
    done:
        mov r2, r4
        ret

print:
    out 1, r1
    ret

; ----- EXAMPLE PROGRAM ----- ;