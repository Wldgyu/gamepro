#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

//int won(void);
int display(void);
int dollar(void);
int account(void);
int outputaccount(void);

int accounts = 0;

int main(void)
{
  int c;
  while((c = display()) != 4){
    switch (c)
    {
    case 1: dollar();
        break;
    case 2: account();
        break;
    case 3: outputaccount();
        break;
    
    default:
        break;
    }
  }
}

int display(void){
    int select;
    system("cls");
    printf("환전소\n\n");
    printf("1. 달러\n");
    printf("2. 입금\n");
    printf("3. 출금\n");
    printf("4. 종료\n");
    select = getch() - 48;

    if (select < 1 || select > 4) {
        printf("\n잘못된 입력입니다. 다시 선택해 주세요.\n");
        getch();  // 메시지를 읽을 시간을 주기 위해 대기
        return display();  // 다시 메뉴로 돌아감
    }

    return select;
}

/*int won (void){
    system("cls");
   unsigned long money, num;
   unsigned long m_unit[]={100000000, 10000, 1};
   int i;
   char *unit01[]={"억", "만", "원"};	

   printf("금액을 입력하고 Enter>");

   if (scanf("%ld", &money) != 1) {
        printf("잘못된 입력입니다. 숫자를 입력하세요.\n");
        return -1;  // 입력 오류시 함수 종료
    }
   printf("입력한 금액: %ld원\n", money);
   printf("\n화폐단위\n");
   for(i=0; i<3; i++)
   {
 	num=money/m_unit[i];
	if(!num)
		continue;

	printf("%ld%s ", num, unit01[i]);
	money=money-num*m_unit[i];
   }

   printf("\n");
   printf("계속하려면 아무 키나 누르세요...");
    getch();
   return 0;

} */

int dollar(void){
    system("cls");
    double money, exchangeMoney, dollars;

     printf("현재 환율 (원/달러)을 입력하고 Enter>");
     scanf("%lf", &exchangeMoney);

     printf("환전할 원화 금액을 입력하고 Enter>");
     scanf("%lf", &money);

    dollars = money / exchangeMoney;

    printf("\n%.2f 원은 %.2f 달러입니다.\n", money, dollars);

    printf("계속하려면 아무 키나 누르세요...");
    getch();

    return 0;
}

int account(void){
    system("cls");
    int money, sum;
    int c;
    while(c != 2){
    
      printf("입금할 금액을 입력하고 Enter>");
        scanf("%d", &money);

      accounts += money;
       printf("입력 하신 금액은 : %d원\n", money);
        printf("현재까지 입금된 총 금액: %d원\n", accounts);

       printf("계속하려면 1번 뒤로 돌아가기 2번 :");
       scanf("%d", &c);
  }
   getch();

}

int outputaccount(void){
    system("cls");
    int money, sum;
    int c;
    while (c != 2){
        printf("출금할 금액을 입력하고 Enter>");
        scanf("%d", &money);
        accounts -= money;
        printf("출금 하신 금액은 : %d원\n", money);
        printf("현재 통장 잔액은 금액: %d원\n", accounts);
        printf("계속하려면 1번 뒤로 돌아가기 2번 :");
       scanf("%d", &c);

        }
        getch();
    
}
