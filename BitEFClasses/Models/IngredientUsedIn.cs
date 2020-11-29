using System;
using System.Collections.Generic;

namespace BitEFClasses.Models
{
    public partial class IngredientUsedIn
    {
        public int IngredientId { get; set; }
        public int StyleId { get; set; }

        public virtual Ingredient Ingredient { get; set; }
        public virtual Style Style { get; set; }
    }
}
