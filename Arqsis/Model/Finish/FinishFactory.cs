using Microsoft.AspNetCore.Mvc;

namespace Arqsis.Model.Finish
{
    public class FinishFactory
    {
        public static Finish Create(string name)
        {
            Finish finish = new Finish();
            finish.Name = name;

            return finish;
        }
    }
}