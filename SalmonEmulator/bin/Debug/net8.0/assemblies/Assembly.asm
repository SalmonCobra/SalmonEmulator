ldi r0 10
ldi r1 1

loop:
sub r0 r1
out 1 r0
jne loop
halt