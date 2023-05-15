class Program {
    struct city {
        public string name;
        public int num;
        public int[] numCity;
        public int level;
    }

    static void Checkcity(int num ,ref int[] citynum , int x,ref int j){
        for (int k = 0 ; k < num ; k++){
            if (x != citynum[k]){
                citynum[j] = x;
                return;
            }else{
                Console.WriteLine("Invalid ID");
                j--;
                return;
            }
        }
    }

    static void show(int number,city[] City){
        for (int i = 0;i <= number-1; i++){
            Console.WriteLine($"City {i} ,{City[i].name} ,{City[i].level}");
        }
    }

    static void Main(string[] args) {
        int number = int.Parse(Console.ReadLine());

        city[] City = new city[number];

        for (int i = 0;i < number; i++){
            City[i].level = 0;
            Console.WriteLine($"City number : {i}");
            Console.Write("City name : ");
            City[i].name = Console.ReadLine();
            Console.Write("number of cities contact with this city :");
            City[i].num = int.Parse(Console.ReadLine());
            if (City[i].num != 0){
                int[] citynum = new int[City[i].num];
                Console.Write("The number of the city that corresponds to this city :");
                citynum[0] = int.Parse(Console.ReadLine());
                for (int j = 1 ; j < City[i].num ; j++){
                    Console.Write("The number of the city that corresponds to this city :");
                    int x = int.Parse(Console.ReadLine());
                    Checkcity(City[i].num,ref citynum,x,ref j);
                }
            }
        }

        show(number,City);

        bool Z;

        do{
        Z = false;
        string Event = Console.ReadLine();
        switch(Event){
            case "Outbreak":
                int EventCity_O = int.Parse(Console.ReadLine());
                if (City[EventCity_O].level < 3){
                    City[EventCity_O].level += 2;
                    if (City[EventCity_O].level < 3){
                        City[EventCity_O].level = 3;
                    }
                }
                for (int i = 0 ; i < City[EventCity_O].numCity.Length ; i++){
                    if (City[City[EventCity_O].numCity[i]].level < 3){
                        City[City[EventCity_O].numCity[i]].level += 1;
                        if (City[City[EventCity_O].numCity[i]].level < 3){
                            City[City[EventCity_O].numCity[i]].level = 3;
                        }
                    }
                }
                show(number,City);
                break;
            case "Vaccinate":
                int EventCity_V = int.Parse(Console.ReadLine());
                City[EventCity_V].level = 0;
                show(number,City);
                break;
            case "Lockdown":
                int EventCity_L = int.Parse(Console.ReadLine());
                if (City[EventCity_L].level > 0){
                    City[EventCity_L].level -= 1;
                    if (City[EventCity_L].level < 0){
                        City[EventCity_L].level = 0;
                    }
                }
                for (int i = 0 ; i < City[EventCity_L].numCity.Length ; i++){
                    if (City[City[EventCity_L].numCity[i]].level > 0){
                        City[City[EventCity_L].numCity[i]].level -= 1;
                        if (City[City[EventCity_L].numCity[i]].level < 0){
                            City[City[EventCity_L].numCity[i]].level = 0;
                        }
                    }
                }
                show(number,City);
                break;
            case "Spread":
                for (int i = 0;i <= number-1; i++){
                    for (int l = 0 ; l < City[i].numCity.Length ; l++){
                        if (City[City[i].numCity[l]].level > City[i].level){
                            if (City[i].level < 3){
                                City[i].level += 1;
                                if (City[i].level > 3){
                                City[i].level = 3;
                                }
                            }
                        }
                    }
                }
                break;
            case "Exit":
                break;
            default:
                Console.WriteLine("Invalid");
                Z = true;
                break;

        }

        }while(Z);

    }
}