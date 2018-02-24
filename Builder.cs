using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleHashCode
{
    public static class Builder
    {

        public static Pizza[] build(string path)
        {
            var reader = new StreamReader(path);
            var pizzaSettings = reader.ReadLine();

            //Number of rows
            var R = Convert.ToInt32(pizzaSettings.Split(' ')[0]);
            //Number of columns
            var C = Convert.ToInt32(pizzaSettings.Split(' ')[1]);
            //Minimun number of each ingredients cells in a slice
            var L = Convert.ToInt32(pizzaSettings.Split(' ')[2]);
            //Maximun total number of cells of a slice
            var H = Convert.ToInt32(pizzaSettings.Split(' ')[3]);



            //var totalPizzas = (R*C)/25 + (R*C % 25);
            var pizzas = new Pizza[1];


            /*for (var pizzaNumber=0;pizzaNumber<totalPizzas; pizzaNumber++)
            {
                var minRow= pizzaNumber * R;
                var minCol= pizzaNumber * C;
                */



                var tempMaxRow = R;
                var tempMaxCol = C;

                var pizza = new Pizza(tempMaxRow, tempMaxCol, L, H);

                for (var r = 0; r < tempMaxRow; r++)
                {
                    var row = reader.ReadLine();

                    for (var c = 0; c < tempMaxCol; c++)
                    {
                        var value = row[c];
                        pizza.add(r, c, value.ToString());
                    }
                }
                pizzas[0] = pizza;
            //}
            

            return pizzas;
        }
    }
}
