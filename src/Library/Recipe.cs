//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;

namespace Full_GRASP_And_SOLID.Library
{
    public class Recipe
    {
        private ArrayList steps = new ArrayList();

        public Product FinalProduct { get; set; }

        public void AddStep(Step step)
        {
            this.steps.Add(step);
        }

        public void RemoveStep(Step step)
        {
            this.steps.Remove(step);
        }

        public void PrintRecipe()
        {
            Console.WriteLine($"Receta de {this.FinalProduct.Description}:");
            foreach (Step step in this.steps)
            {
                Console.WriteLine($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time}s");
                                    
            }
            Console.WriteLine($"El costo de produccion total es de {GetProductionCost()}");    
        }

        
    
        public double GetProductionCost()
    {
        double CostoTotal = 0;

        
        foreach (Step step in this.steps)
        {
            
            double stepCost = step.Input.UnitCost + (step.Time / 3600.0) * step.Equipment.HourlyCost;
            CostoTotal += stepCost;
        }

        return CostoTotal;
    }




    }
}
