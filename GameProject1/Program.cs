﻿using System;

namespace GameProject1
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new SkelletonGame())
                game.Run();
        }
    }
}
