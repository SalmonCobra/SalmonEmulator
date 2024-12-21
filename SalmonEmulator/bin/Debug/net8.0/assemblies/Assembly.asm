ldi r1, 1
ldi r2, 1
ldi r3, 4




call h
call e
call l
call l
call o
call newline
call w
call o
call r
call l
call d

out 11
halt


;r1 = col
;r2 = line
;r3 = strength
a:
    push r4
    push r5
    mov r4, r1 ; r4 = x
    mov r5, r2 ; r5 = y

    ; first line
    add r4, 1
    call stDisplayBuffer
    sub r4, 1

    ; second line
    add r5, 1
    call stDisplayBuffer
    add r4, 2
    call stDisplayBuffer
    sub r4 2

    ; third line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    ; fourth line
    add r5, 1
    call stDisplayBuffer
    add r4, 2
    call stDisplayBuffer
    sub r4 2

    ; fifth line
    add r5, 1
    call stDisplayBuffer
    add r4, 2
    call stDisplayBuffer
    sub r4 2

    add r1, 4

    pop r5
    pop r4
    ret
b:
    push r4
    push r5
    mov r4, r1 ; r4 = x
    mov r5, r2 ; r5 = y

    ; first line
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    sub r4, 2

    ; second line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    ; third line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    sub r4, 2

    ; fourth line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    ; fifth line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    add r1, 4

    pop r5
    pop r4
    ret
c:
    push r4
    push r5
    mov r4, r1 ; r4 = x
    mov r5, r2 ; r5 = y

    ; first line
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    ; second line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    sub r4, 2

    ; third line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    sub r4, 2

    ; fourth line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    sub r4, 2

    ; fifth line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    add r1, 4

    pop r5
    pop r4
    ret
d:
    push r4
    push r5
    mov r4, r1 ; r4 = x
    mov r5, r2 ; r5 = y

    ; first line
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    sub r4, 2

    ; second line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    ; third line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    ; fourth line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    ; fifth line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    add r1, 4

    pop r5
    pop r4
    ret
e:
    push r4
    push r5
    mov r4, r1 ; r4 = x
    mov r5, r2 ; r5 = y

    ; first line
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    ; second line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    sub r4, 2

    ; third line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    sub r4, 2

    ; fourth line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    sub r4, 2

    ; fifth line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    add r1, 4

    pop r5
    pop r4
    ret
f:
    push r4
    push r5
    mov r4, r1 ; r4 = x
    mov r5, r2 ; r5 = y

    ; first line
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    ; second line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    sub r4, 2

    ; third line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    sub r4, 2

    ; fourth line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    sub r4, 2

    ; fifth line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    sub r4, 2

    add r1, 4

    pop r5
    pop r4
    ret
g:
    push r4
    push r5
    mov r4, r1 ; r4 = x
    mov r5, r2 ; r5 = y

    ; first line
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    ; second line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    sub r4, 2

    ; third line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    sub r4, 2

    ; fourth line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    ; fifth line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    add r1, 4

    pop r5
    pop r4
    ret
h:
    push r4
    push r5
    mov r4, r1 ; r4 = x
    mov r5, r2 ; r5 = y

    ; first line
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    ; second line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    ; third line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    ; fourth line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    ; fifth line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    add r1, 4

    pop r5
    pop r4
    ret
i:
    push r4
    push r5
    mov r4, r1 ; r4 = x
    mov r5, r2 ; r5 = y

    ; first line
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    ; second line
    add r5, 1
    ; call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    sub r4, 2

    ; third line
    add r5, 1
    ; call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    sub r4, 2

    ; fourth line
    add r5, 1
    ; call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    sub r4, 2

    ; fifth line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    add r1, 4

    pop r5
    pop r4
    ret
j:
    push r4
    push r5
    mov r4, r1 ; r4 = x
    mov r5, r2 ; r5 = y

    ; first line
    ; call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    ; second line
    add r5, 1
    ; call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    ; third line
    add r5, 1
    ; call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    ; fourth line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    ; fifth line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    add r1, 4

    pop r5
    pop r4
    ret
k:
    push r4
    push r5
    mov r4, r1 ; r4 = x
    mov r5, r2 ; r5 = y

    ; first line
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    ; second line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    ; third line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    sub r4, 2

    ; fourth line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    ; fifth line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    add r1, 4

    pop r5
    pop r4
    ret
l:
    push r4
    push r5
    mov r4, r1 ; r4 = x
    mov r5, r2 ; r5 = y

    ; first line
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    sub r4, 2

    ; second line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    sub r4, 2

    ; third line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    sub r4, 2

    ; fourth line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    sub r4, 2

    ; fifth line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    add r1, 4

    pop r5
    pop r4
    ret
m:
    push r4
    push r5
    mov r4, r1 ; r4 = x
    mov r5, r2 ; r5 = y

    ; first line
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    ; second line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    ; third line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    ; fourth line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    ; fifth line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    add r1, 4

    pop r5
    pop r4
    ret
n:
    push r4
    push r5
    mov r4, r1 ; r4 = x
    mov r5, r2 ; r5 = y

    ; first line
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    ; second line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    ; third line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    ; fourth line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    ; fifth line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    add r1, 4

    pop r5
    pop r4
    ret
o:
    push r4
    push r5
    mov r4, r1 ; r4 = x
    mov r5, r2 ; r5 = y

    ; first line
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    ; second line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    ; third line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    ; fourth line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    ; fifth line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    add r1, 4

    pop r5
    pop r4
    ret
p:
    push r4
    push r5
    mov r4, r1 ; r4 = x
    mov r5, r2 ; r5 = y

    ; first line
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    sub r4, 2

    ; second line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    ; third line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    ; fourth line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    sub r4, 2

    ; fifth line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    sub r4, 2

    add r1, 4

    pop r5
    pop r4
    ret
q:
    push r4
    push r5
    mov r4, r1 ; r4 = x
    mov r5, r2 ; r5 = y

    ; first line
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    ; second line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    ; third line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    ; fourth line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    ; fifth line
    add r5, 1
    ; call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    add r1, 4

    pop r5
    pop r4
    ret
r:
    push r4
    push r5
    mov r4, r1 ; r4 = x
    mov r5, r2 ; r5 = y

    ; first line
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    sub r4, 2

    ; second line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    ; third line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    sub r4, 2

    ; fourth line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    ; fifth line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    add r1, 4

    pop r5
    pop r4
    ret
s:
    push r4
    push r5
    mov r4, r1 ; r4 = x
    mov r5, r2 ; r5 = y

    ; first line
    ; call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    ; second line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    sub r4, 2

    ; third line
    add r5, 1
    ; call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    sub r4, 2

    ; fourth line
    add r5, 1
    ; call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    ; fifth line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    sub r4, 2

    add r1, 4

    pop r5
    pop r4
    ret
t:
    push r4
    push r5
    mov r4, r1 ; r4 = x
    mov r5, r2 ; r5 = y

    ; first line
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    ; second line
    add r5, 1
    ; call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    sub r4, 2

    ; third line
    add r5, 1
    ; call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    sub r4, 2

    ; fourth line
    add r5, 1
    ; call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    sub r4, 2

    ; fifth line
    add r5, 1
    ; call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    sub r4, 2

    add r1, 4

    pop r5
    pop r4
    ret
u:
    push r4
    push r5
    mov r4, r1 ; r4 = x
    mov r5, r2 ; r5 = y

    ; first line
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    ; second line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    ; third line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    ; fourth line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    ; fifth line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    add r1, 4

    pop r5
    pop r4
    ret
v:
    push r4
    push r5
    mov r4, r1 ; r4 = x
    mov r5, r2 ; r5 = y

    ; first line
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    ; second line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    ; third line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    ; fourth line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    ; fifth line
    add r5, 1
    ; call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    sub r4, 2

    add r1, 4

    pop r5
    pop r4
    ret
w:
    push r4
    push r5
    mov r4, r1 ; r4 = x
    mov r5, r2 ; r5 = y

    ; first line
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    ; second line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    ; third line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    ; fourth line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    ; fifth line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    add r1, 4

    pop r5
    pop r4
    ret
x:
    push r4
    push r5
    mov r4, r1 ; r4 = x
    mov r5, r2 ; r5 = y

    ; first line
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    ; second line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    ; third line
    add r5, 1
    ; call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    sub r4, 2

    ; fourth line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    ; fifth line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    add r1, 4

    pop r5
    pop r4
    ret
y:
    push r4
    push r5
    mov r4, r1 ; r4 = x
    mov r5, r2 ; r5 = y

    ; first line
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    ; second line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    ; third line
    add r5, 1
    ; call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    sub r4, 2

    ; fourth line
    add r5, 1
    ; call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    sub r4, 2

    ; fifth line
    add r5, 1
    ; call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    sub r4, 2

    add r1, 4

    pop r5
    pop r4
    ret
z:
    push r4
    push r5
    mov r4, r1 ; r4 = x
    mov r5, r2 ; r5 = y

    ; first line
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    ; second line
    add r5, 1
    ; call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    ; third line
    add r5, 1
    ; call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    sub r4, 2

    ; fourth line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    add r4, 1
    ; call stDisplayBuffer
    sub r4, 2

    ; fifth line
    add r5, 1
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    add r4, 1
    call stDisplayBuffer
    sub r4, 2

    add r1, 4

    pop r5
    pop r4
    ret
space:
    add r1, 4
    ret
newline:
    ldi r1, 1
    add r2, 6
    ret

; r3 = strength
; r4 = x
; r5 = y
stDisplayBuffer:
    shl r4, 12
    shl r5, 4
    push r6
    mov r6, r4
    or r6, r5
    or r6, r3

    out 10, r6

    shr r4, 12
    shr r5, 4
    pop r6
    ret
