using System;
using System.Collections.Generic;
using System.Text;

namespace AI
{
    class AI
    {
        public double learningRate = 0.5;
        public double gamma = 0.7;

        public List<string> qState = new List<string>();
        public List<List<double>> qReward = new List<List<double>>();


        public void Start()
        {
            for (int i = 0; i < 100; i++)
            {
                Lap();
            }

            Console.ReadKey();
        }

        private Map.Movement GetDirection(string state, double epsilon)
        {
            int index = qState.IndexOf(state);
            var a = qReward[index];
            double higherNumber = -1000;
            double higherIndex = 0;
            for (int i = 0; i < a.Count; i++)
            {
                if (a[i] > higherNumber)
                {
                    higherNumber = a[i];
                    higherIndex = i;
                }
            }
            return new Random().Next(0, 10) <= epsilon*10 ? (Map.Movement)new Random().Next(0, 3) : (Map.Movement)higherIndex; 

        }

        private void Lap()
        {
            Map map = new Map();
            
            bool dead = false;
            bool win = false;
            string currentState = map.Start();
            string stateP1 = currentState;
            Map.Movement currentAction;
            Map.Movement actionP1;
            int currentReward = 0;
            
            


            while (!(dead || win))
            {
                if (!qState.Contains(currentState))
                {
                    qState.Add(currentState);
                    qReward.Add(new List<double> { 0, 0, 0, 0 });
                }
                currentAction = GetDirection(currentState, 0.1);
                var result = map.Move(currentAction);

                stateP1 = result.Item1;
                actionP1 = GetDirection(currentState,0);

                currentReward += result.Item2;

                if (currentReward <= -100)
                {
                    dead = true;
                }
                if (currentReward > 1)
                {
                    win = true;
                }

                if (!qState.Contains(stateP1))
                {
                    qState.Add(stateP1);
                    qReward.Add(new List<double> { 0, 0, 0, 0 });
                }
                
                

                //Il faut faire le calcul
                // Q[st][at] = Q[st][at] + lr*( currentReward + gamma*Q[stp1][atp1] - Q[st][at] ) 

                //qReward[qState.IndexOf(currentState)][(int)currentAction] = qReward[qState.IndexOf(currentState)][(int)currentAction] + learningRate * (currentReward + gamma * qReward[qState.IndexOf(stateP1)][(int)actionP1] - qReward[qState.IndexOf(currentState)][(int)currentAction]);

                //Découpage : 

                var a = qReward[qState.IndexOf(currentState)][(int)currentAction];
                var b = qReward[qState.IndexOf(stateP1)][(int)actionP1];
                var result0 = a + learningRate * (currentReward + gamma * b - a);
                qReward[qState.IndexOf(currentState)][(int)currentAction] = result0;
                currentState = stateP1;
            }
        }

    }
}
