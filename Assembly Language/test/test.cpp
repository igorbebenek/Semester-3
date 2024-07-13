#include <iostream>

typedef union {
	unsigned char BYTE;
	struct {
		unsigned char a : 3;
		unsigned char b : 2;
		unsigned char c : 3;
	} bits;
} un_X;



int main()
{
	//Zad2

	uint8_t a = 11;  
	uint16_t y;      

	_asm {
		movzx eax, a; 
		cmp al, 10; 
		jle else_part; 

		mov ebx, eax; 
		shl ebx, 2; 
		add ebx, eax; 
		shr eax, 1; 
		add ebx, eax; 
		mov y, bx; 
		jmp end_if

		else_part :
		shl ax, 1; 
			mov y, ax; 

			end_if :
	}
	std::cout << "Wynik " << y << std::endl; // 60.5 zaokraglone do 60
		

	//Zad1
	
	//Kod _asm

	un_X x;
	x.BYTE = 0; 

	__asm {
		mov al, x.BYTE; 

		loop_start :
		mov ah, al; 
			and ah, 7; 
			mov bl, al; 
			shr bl, 3; 
			and bl, 3; 

			shl bl, 1; 
			add bl, ah; 
			inc al; 
			and bl, 7; 
			shl bl, 5; 

			mov dh, al; 
			and dh, 0x1F; 
			or dh, bl; 
			mov x.BYTE, dh; 

			cmp bl, 0x60; 
			jb loop_start; 
	}

	std::cout << "Wynik: " << static_cast<int>(x.BYTE) << std::endl;

}