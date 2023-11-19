using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constant
{
    //sürekli newlememek için statik yazılır. statik olanlar newlenmez.direkt yazılır.
    public static class Messages
    {
        //Publicler PascalCase yazılır.
        public static string ProductAdded = "Ürün Eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz.";
    }
}
