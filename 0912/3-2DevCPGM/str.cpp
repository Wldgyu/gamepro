#include <stdio.h>

int main(){
	char string[20];
	string = "abcd";
	int i;
	printf("%d\n", sizeof(string));
	i = printf("%s\n", string);
	printf("%d\n", i);
	
	return 0;
}
