using System;

namespace Phone_Hackr
{
    class Program
    {
        private static double version = 1.0;
        static void Main(string[] args)
        {
            var phone = new Phone();
            while(true){
                Console.WriteLine("Phone_Hack {0:N2}", version);
                Console.Write("> ");
                var com = Console.ReadLine();
                var arg = com.Split(' ');

                if(arg[0] == "call"){
                    phone.MakeCall(arg[1], arg[2]);
                } else if (arg[0] == "text"){
                    phone.SendText(arg[1]);
                } else if (arg[0] == "spam"){
                    if(arg[1] == "call"){
                        if(arg.Length > 3){
                            phone.SpamCall(arg[2], Convert.ToInt32(arg[2]), arg[3]);
                        } else {
                            phone.SpamCall(arg[2], Convert.ToInt32(arg[2]));
                        }
                    } else if(arg[1] == "text"){
                        if(arg.Length > 3){
                            phone.SpamText(arg[2], Convert.ToInt32(arg[2]), arg[3]);
                        } else {
                            phone.SpamText(arg[2], Convert.ToInt32(arg[2]));
                        }
                    }
                } else if (arg[0] == "gen"){
                    phone.GenerateTwiml(arg[1]);
                }
            }
        }
    }
}
