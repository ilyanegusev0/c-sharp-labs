using InteractiveMenu;
using InteractiveMenu.Items;
using RestaurantManagementSystem;
using RestaurantManagementSystem.Enums;
using Utils;

namespace App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                ShowMainMenu();
            }
        }

        static void ShowMainMenu()
        {
            Console.Clear();

            Menu menu = new Menu();

            List<MenuItem> items = new List<MenuItem>()
            {
                new TextItem("[ MAIN MENU ]", ConsoleColor.Red),
                new EmptyItem(),
                new TextItem(" Catalog:", ConsoleColor.Yellow),
                new ActionItem(" - Show restaurant menu", ShowRestaurantMenu),
                new ActionItem(" - Show all orders", ShowOrders),
                new ActionItem(" - Show all tables", ShowTables),
                new EmptyItem(),
                new TextItem(" Admin actions:", ConsoleColor.Yellow),
                new ActionItem(" - Add new position", AddNewPosition),
                new ActionItem(" - Add new table", AddNewTable),
                new EmptyItem(),
                new TextItem(" Client actions:", ConsoleColor.Yellow),
                new ActionItem(" - Make order", MakeOrder),
                new ActionItem(" - Reserve table", ReserveTable),
                new EmptyItem(),
                new ActionItem(" - Exit", () => Environment.Exit(0))
            };

            menu.Show(items);
        }

        // CATALOG

        static void ShowRestaurantMenu()
        {
            Console.Clear();

            ConsoleEx.WriteLine("[ RESTAURANT MENU ]\n", ConsoleColor.Red);

            Restaurant.Instance.ShowAllItems();

            Menu menu = new Menu();

            List<MenuItem> navItems = new List<MenuItem>()
            {
                new ActionItem(" - Go back", ShowMainMenu),
                new ActionItem(" - Exit", () => Environment.Exit(0))
            };

            menu.Show(navItems);
        }

        static void ShowOrders()
        {
            Console.Clear();

            ConsoleEx.WriteLine("[ ORDERS ]\n", ConsoleColor.Red);

            Restaurant.Instance.ShowAllOrders();

            Menu menu = new Menu();
            List<MenuItem> navItems = new List<MenuItem>()
            {
                new ActionItem(" - Go back", ShowMainMenu),
                new ActionItem(" - Exit", () => Environment.Exit(0))
            };
            menu.Show(navItems);
        }

        static void ShowTables()
        {
            Console.Clear();

            ConsoleEx.WriteLine("[ TABLES ]\n", ConsoleColor.Red);

            Restaurant.Instance.ShowAllTables();

            Menu menu = new Menu();
            List<MenuItem> navItems = new List<MenuItem>()
            {
                new ActionItem(" - Go back", ShowMainMenu),
                new ActionItem(" - Exit", () => Environment.Exit(0))
            };
            menu.Show(navItems);
        }

        // ADMIN ACTIONS

        static void AddNewPosition()
        {
            Console.Clear();
            ConsoleEx.WriteLine("[ NEW POSITION ]\n", ConsoleColor.Red);

            Menu menu = new Menu();

            List<MenuItem> items = new List<MenuItem>()
            {
                new TextItem(" Choose position type: ", ConsoleColor.Yellow),
                new ActionItem(" - Dish", CreateNewDish),
                new ActionItem(" - Drink", CreateNewDrink)
            };

            BaseItem? item = (BaseItem?)menu.Show(items);

            if (item == null)
            {
                ShowMainMenu();
                return;
            }

            List<MenuItem> confirm = new List<MenuItem>()
            {
                new TextItem("\n Do you want to save this item?", ConsoleColor.Yellow),
                new ActionItem(" - Save", () => {
                        Restaurant.Instance.AddItem(item);
                        ShowMainMenu();
                }),
                new ActionItem(" - Clear", AddNewPosition),
                new ActionItem(" - Cancel", ShowMainMenu)
            };

            menu.Show(confirm);

            return;
        }

        static DishItem CreateNewDish()
        {
            Menu menu = new Menu();

            string title;
            while (true)
            {
                ConsoleEx.Write("\n Enter title: ", ConsoleColor.Yellow);
                title = Console.ReadLine()!;

                if (string.IsNullOrWhiteSpace(title))
                {
                    ConsoleEx.WriteLine(" Value can't be empty.", ConsoleColor.Red);
                    continue;
                }

                if (!title.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
                {
                    ConsoleEx.WriteLine(" Value must contain only letters.", ConsoleColor.Red);
                    continue;
                }

                break;
            }

            List<MenuItem> categoryItems = new List<MenuItem>()
            {
                new TextItem("\n Select category:", ConsoleColor.Yellow)
            };

            foreach (var cat in Enum.GetValues(typeof(DishCategory)))
            {
                categoryItems.Add(new OptionItem($" - {cat.ToString()}", cat));
            }

            var result = menu.Show(categoryItems)!;

            if (result == null)
                return default!;

            DishCategory category = (DishCategory)result!;

            double weight;
            while (true)
            {
                ConsoleEx.Write("\n Enter weight (grams): ", ConsoleColor.Yellow);
                if (!double.TryParse(Console.ReadLine(), out weight))
                {
                    ConsoleEx.WriteLine(" Value must be a digit.", ConsoleColor.Red);
                    continue;
                }

                if (weight < 1)
                {
                    ConsoleEx.WriteLine(" Weight must be more than 0.", ConsoleColor.Red);
                    continue;
                }

                break;
            }

            int calories;
            while (true)
            {
                ConsoleEx.Write("\n Enter calories (kcal): ", ConsoleColor.Yellow);
                if (!int.TryParse(Console.ReadLine(), out calories))
                {
                    ConsoleEx.WriteLine(" Value must be a digit.", ConsoleColor.Red);
                    continue;
                }

                if (calories < 0)
                {
                    ConsoleEx.WriteLine(" Calories must be more or equals 0.", ConsoleColor.Red);
                    continue;
                }

                break;
            }

            decimal price;
            while (true)
            {
                ConsoleEx.Write("\n Enter price (UAH): ", ConsoleColor.Yellow);
                if (!decimal.TryParse(Console.ReadLine(), out price))
                {
                    ConsoleEx.WriteLine(" Value must be a digit.", ConsoleColor.Red);
                    continue;
                }

                if (price < 0)
                {
                    ConsoleEx.WriteLine(" Price must be more or equals 0.", ConsoleColor.Red);
                    continue;
                }

                break;
            }

            return new DishItem(title, category, weight, calories, price);
        }

        static DrinkItem CreateNewDrink()
        {
            string title;
            while (true)
            {
                ConsoleEx.Write("\n Enter title: ", ConsoleColor.Yellow);
                title = Console.ReadLine()!;

                if (string.IsNullOrWhiteSpace(title))
                {
                    ConsoleEx.WriteLine(" Value can't be empty.", ConsoleColor.Red);
                    continue;
                }

                if (!title.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
                {
                    ConsoleEx.WriteLine(" Value must contain only letters.", ConsoleColor.Red);
                    continue;
                }

                break;
            }

            Menu menu = new Menu();

            List<MenuItem> categoryItems = new List<MenuItem>()
            {
                new TextItem("\n Select category:", ConsoleColor.Yellow)
            };

            foreach (var cat in Enum.GetValues(typeof(DrinkCategory)))
            {
                categoryItems.Add(new OptionItem($" - {cat.ToString()}", cat));
            }

            var result = menu.Show(categoryItems);

            if (result == null)
                return default!;

            DrinkCategory category = (DrinkCategory)result;

            double volume;
            while (true)
            {
                ConsoleEx.Write("\n Enter volume (ml): ", ConsoleColor.Yellow);
                if (!double.TryParse(Console.ReadLine(), out volume))
                {
                    ConsoleEx.WriteLine(" Value must be a digit.", ConsoleColor.Red);
                    continue;
                }

                if (volume < 1)
                {
                    ConsoleEx.WriteLine(" Volume must be more than 0.", ConsoleColor.Red);
                    continue;
                }

                break;
            }

            int calories;
            while (true)
            {
                ConsoleEx.Write("\n Enter calories (kcal): ", ConsoleColor.Yellow);
                if (!int.TryParse(Console.ReadLine(), out calories))
                {
                    ConsoleEx.WriteLine(" Value must be a digit.", ConsoleColor.Red);
                    continue;
                }

                if (calories < 0)
                {
                    ConsoleEx.WriteLine(" Calories must be more or equals 0.", ConsoleColor.Red);
                    continue;
                }

                break;
            }

            double alcoholPercentage;
            while (true)
            {
                ConsoleEx.Write("\n Enter alcohol percentage (%): ", ConsoleColor.Yellow);
                if (!double.TryParse(Console.ReadLine(), out alcoholPercentage))
                {
                    ConsoleEx.WriteLine(" Value must be a digit.", ConsoleColor.Red);
                    continue;
                }

                if (alcoholPercentage < 0 || alcoholPercentage > 100)
                {
                    ConsoleEx.WriteLine(" Alcohol percentage must be between 0 and 100", ConsoleColor.Red);
                    continue;
                }

                break;
            }

            decimal price;
            while (true)
            {
                ConsoleEx.Write("\n Enter price (UAH): ", ConsoleColor.Yellow);
                if (!decimal.TryParse(Console.ReadLine(), out price))
                {
                    ConsoleEx.WriteLine(" Value must be a digit.", ConsoleColor.Red);
                    continue;
                }

                if (price < 0)
                {
                    ConsoleEx.WriteLine(" Price must be more or equals 0.", ConsoleColor.Red);
                    continue;
                }

                break;
            }

            return new DrinkItem(title, category, volume, calories, alcoholPercentage, price);
        }

        static void AddNewTable()
        {
            Console.Clear();

            ConsoleEx.WriteLine("[ NEW TABLE ]", ConsoleColor.Red);

            int tableNumber;
            while (true)
            {
                ConsoleEx.Write("\n Enter table number: ", ConsoleColor.Yellow);
                if (!int.TryParse(Console.ReadLine(), out tableNumber))
                {
                    ConsoleEx.WriteLine(" Value must be a digit.", ConsoleColor.Red);
                    continue;
                }

                if (tableNumber < 1)
                {
                    ConsoleEx.WriteLine(" Table number must be more than 0", ConsoleColor.Red);
                    continue;
                }

                if (Restaurant.Instance.SearchTableByNumber(tableNumber) != null)
                {
                    ConsoleEx.WriteLine(" Table with same number is already exists.", ConsoleColor.Red);
                    continue;
                }

                break;
            }

            int seats;
            while (true)
            {
                ConsoleEx.Write("\n Enter count of seats: ", ConsoleColor.Yellow);
                if (!int.TryParse(Console.ReadLine(), out seats))
                {
                    ConsoleEx.WriteLine(" Count of seats must be a digit.", ConsoleColor.Red);
                    continue;
                }

                if (seats < 1)
                {
                    ConsoleEx.WriteLine(" Count of seats must be more than 0.", ConsoleColor.Red);
                    continue;
                }

                break;
            }

            Menu menu = new Menu();

            List<MenuItem> confirmItems = new List<MenuItem>()
            {
                new TextItem("\n Do you want to save this table?"),
                new ActionItem(" - Save", () =>
                {
                    Restaurant.Instance.AddTable(new Table(tableNumber, seats));
                    ShowMainMenu();
                }),
                new ActionItem(" - Clear", AddNewTable),
                new ActionItem(" - Cancel", ShowMainMenu)
            };

            menu.Show(confirmItems);
        }

        // CLIENT ACTIONS

        static void MakeOrder()
        {
            Menu menu = new Menu();
            Dictionary<BaseItem, int> orderItems = new Dictionary<BaseItem, int>();

            bool isOrderFinished = false;
            while (!isOrderFinished)
            {
                Console.Clear();
                ConsoleEx.WriteLine("[ NEW ORDER ]\n", ConsoleColor.Red);

                List<MenuItem> items1 = new List<MenuItem>()
                {
                    new TextItem($" Your order ({orderItems.Sum(o => o.Value)} items):"),
                };

                foreach (var item in orderItems)
                {
                    var itemKey = item.Key;
                    var itemCount = item.Value;

                    items1.Add(new TextItem($" - {itemKey.Title} x{itemCount} ({itemCount * itemKey.Price} UAH)"));
                }

                List<MenuItem> items2 = new List<MenuItem>()
                {
                    new EmptyItem(),
                    new TextItem($" Total price: {orderItems.Sum(o => o.Key.Price * o.Value)} UAH"),
                    new EmptyItem(),
                    new TextItem(" Select at least one position and press ConsoleKey.Escape to continue:"),

                };
                foreach (var item in Restaurant.Instance.Items)
                {
                    items2.Add(new OptionItem($" - {item.Title}", item));
                }

                var result = menu.Show(items1, items2);

                if (result == null)
                {
                    if (orderItems.Count > 0)
                    {
                        isOrderFinished = true;
                        continue;
                    }
                }

                BaseItem selectedItem = (BaseItem)result!;

                if (orderItems.ContainsKey(selectedItem))
                    orderItems[selectedItem]++;
                else
                    orderItems.Add(selectedItem, 1);
            }

            if (isOrderFinished)
            {
                //int tableNumber = InputHelper.InputWithValidation<int>(
                //    "\n Enter table number: ",
                //    v => v.ToString().All(char.IsDigit),
                //    " Table number must be a digit");

                int tableNumber;
                while (true)
                {
                    ConsoleEx.Write("\n Enter table number: ", ConsoleColor.Yellow);
                    if (!InputEx.TryParse(Console.ReadLine(), out tableNumber, -1))
                    {
                        ConsoleEx.WriteLine(" Value must be a digit.", ConsoleColor.Red);
                        continue;
                    }

                    if (tableNumber < 1)
                    {
                        ConsoleEx.WriteLine(" Value must be more than 0.", ConsoleColor.Red);
                        continue;
                    }

                    Table table = Restaurant.Instance.SearchTableByNumber(tableNumber)!;

                    if (table == null)
                    {
                        ConsoleEx.WriteLine(" Table not found.", ConsoleColor.Red);
                        continue;
                    }

                    if (table.IsReserved)
                    {
                        ConsoleEx.WriteLine(" Table is already reserved. Please, choose another one.", ConsoleColor.Red);
                        continue;
                    }

                    break;
                }

                Order order = new Order(tableNumber);
                foreach (var item in orderItems)
                {
                    order.AddItem(item.Key, item.Value);
                }

                List<MenuItem> confirmItems = new List<MenuItem>()
                {
                    new TextItem("[ NEW ORDER ]"),
                    new EmptyItem(),
                    new TextItem(order.ToString()),
                    new EmptyItem(),
                    new TextItem("\n Confirm?"),
                    new ActionItem(" - Save",
                        () => {
                            Restaurant.Instance.AddOrder(order);
                            ShowMainMenu(); }),
                    new ActionItem(" - Clear", MakeOrder),
                    new ActionItem(" - Cancel", ShowMainMenu)
                };

                // НУЖНО ДОБАВИТЬ СИСТЕМУ ДОБАВЛЕНИЯ СТОЛИКОВ

                menu.Show(confirmItems);
            }
        }

        static void ReserveTable()
        {
            Console.Clear();

            Menu menu = new Menu();
            List<MenuItem> items = new List<MenuItem>()
            {
                new TextItem("[ RESERVE TABLE ]", ConsoleColor.Red),
                new EmptyItem(),
                new TextItem(" Choose a table you want to reserve or enter Escape to exit."),
                new EmptyItem(),
                new TextItem($" TABLES ({Restaurant.Instance.Tables.Count(t => !t.IsReserved)} items):"),
            };

            foreach (var t in Restaurant.Instance.Tables)
            {
                if (t.IsReserved == false)
                    items.Add(new OptionItem($" - Table #{t.Number} | Seats: {t.Seats}", t));
            }

            Table table = (Table)menu.Show(items)!;

            if (table == null)
            {
                ShowMainMenu();
                return;
            }

            List<MenuItem> confirm = new List<MenuItem>()
            {
                new TextItem("\n Confirm?", ConsoleColor.Yellow),
                new ActionItem(" - Save", () =>
                {
                    table.Reserve();
                    ShowMainMenu();
                }),
                new ActionItem(" - Clear", ReserveTable),
                new ActionItem(" - Cancel", ShowMainMenu)
            };

            menu.Show(confirm);
        }
    }
}