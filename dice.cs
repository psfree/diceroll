using System;
					
public class Program
{
	//put variables here. things like money
	int money;
	Random rnd;
	int wager;
	int bet;
	
	public void rollDice() {
		int d1 = rnd.Next(1,7);
		int d2 = rnd.Next(1,7);
		int d3 = rnd.Next(1,7);
		
		Console.WriteLine("Rolling Dice....");
		Console.WriteLine("Dice 1: " +d1);
		Console.WriteLine("Dice 2: " +d2);
		Console.WriteLine("Dice 3: " +d3);
		int sum = d1+d2+d3;
		Console.WriteLine("Rolled ["+d1+","+d2+","+d3+"] ... Total:"+sum);
		if ((d1==d2 && d2==d3) && wager ==5) {
			int winning = bet*30;
			money = money + winning;
			Console.WriteLine("You win 30 to 1 -> $"+ winning);
		}
		else if((sum >10 && sum<18) && wager==1) {
			int winning = bet*1;
			money = money + winning;
			Console.WriteLine("You win 1 to 1 -> $"+ winning);
		}
		else if((sum>3 && sum <11) && wager ==2) {
			int winning = bet*1;
			money = money + winning;
			Console.WriteLine("You win 1 to 1 -> $"+ winning);
		}
		else if( (sum%2==1) && wager==3) {
			int winning = bet*1;
			money = money + winning;
			Console.WriteLine("You win 1 to 1 -> $"+ winning);
		}
		else if((sum%2==0) && wager==4){
			int winning = bet*1;
			money = money + winning;
			Console.WriteLine("You win 1 to 1 -> "+ winning);
		}
		else {
			money = money -bet;
			Console.WriteLine("You lose $"+bet);
		}
	}
	
	public void printIntro() {
		Console.WriteLine("Trump: This is the intro.");
		Console.WriteLine("Trump: My name is Donald Trump and I'm the President.");
		Console.WriteLine("Trump: I need you to get my money back from those damn Red Chinese!");
		Console.WriteLine("Trump: the rules are roll dice or something!");
		//explain the rules here....
		//Console.WriteLine("Trump: rules");
	}
	
	public void printWagers() {
		Console.WriteLine("You have:");
		Console.WriteLine("$" + money);
		Console.ForegroundColor = ConsoleColor.Red;
		Console.WriteLine("Wager Table:");
		Console.ResetColor();
		Console.WriteLine("1=big 2=small");
		Console.WriteLine("3=Odd 4=Even");
		Console.WriteLine("5=Any Triple");	
	}
	
	public void getWager() {
		Console.WriteLine("What wager would you like to make?");
		int a;
		if ( int.TryParse(Console.ReadLine(), out a) ) {
		  if(a>0 && a<6) {
		 	 wager = a;
		 	 }
		 else {
		 	Console.WriteLine("Enter a number from 1 to 5");
		 	getWager();
		 }
		}
		else {
		  Console.WriteLine("Invalid number entered.");
		  getWager();
		}
	}
	
	public void getBet() {
		Console.WriteLine("How much would you like to bet?");
		int a;
		if ( int.TryParse(Console.ReadLine(), out a) ) {
		  if(a>0 && a<=money) {
		 	 bet = a;
		 	 }
		 else {
		 	Console.WriteLine("Enter a valid bet");
		 	getBet();
		 }
		}
		else {
		  Console.WriteLine("Invalid number entered.");
		  getBet();
		}
	}

	
	public Program(int startmoney) {
		rnd = new Random();
		money = startmoney;
	}
	public static void Main()
	{
		Program prog = new Program(200);
		prog.printIntro();

		while(true) {
			if(prog.money>100000) {
				Console.WriteLine("You won all the money! Great Job!");
				return;
			}
			else if(prog.money <=0) {
				Console.WriteLine("You lose, you have no more money. Do you want to play again?");
				string a = Console.ReadLine();
				if(a=="yes") {
					 prog = new Program(200);
					 prog.printIntro();
				}
				else {
					Console.WriteLine("Goodbye!");
					return;
				}
			}
			prog.printWagers();
			prog.getWager();
			prog.getBet();
			prog.rollDice();
		}
	}
}
