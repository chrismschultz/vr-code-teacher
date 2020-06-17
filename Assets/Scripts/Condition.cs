using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    [System.Serializable]
    public class Condition
    {
        public int position;

        public string leftVar;
        public float leftVal;
        public int compare;
        public string rightVar;
        public float rightVal;

        public string conditionStatement;

        public string ifTrueStatement;

        

        public Condition()
        {
            leftVar = "";
            leftVal = 0;
            compare = 0;
            rightVar = "";
            rightVal = 0;
            conditionStatement = "__ __ __";
        }

        public Condition(float left, int comp, float right, int pos)
        {
            leftVar = "";
            leftVal = left;
            compare = comp;
            rightVar = "";
            rightVal = right;
            position = pos;

            conditionStatement = GetConditionStatement();
        }

        public Condition(string leftName, float left, int comp, string rightName, float right, int pos)
        {
            leftVar = leftName;
            leftVal = left;
            compare = comp;
            rightVar = rightName;
            rightVal = right;
            position = pos;
        }

        public string GetConditionStatement()
        {
            string compareString = "__";
            string leftString = "";
            string rightString = "";
            string cond = "";

            switch (compare)
            {
                case 0:
                    compareString = "<";
                    break;
                case 1:
                    compareString = ">";
                    break;
                case 2:
                    compareString = "==";
                    break;
                case 3:
                    compareString = "<=";
                    break;
                case 4:
                    compareString = ">=";
                    break;
                case 5:
                    compareString = "!=";
                    break;
            }



            if (leftVar.CompareTo("") == 0)
            {
                leftString = leftVal.ToString();
            }
            else
            {
                leftString = leftVar;
            }

            if (rightVar.CompareTo("") == 0)
            {
                rightString = rightVal.ToString();
            }
            else
            {
                rightString = rightVar;
            }


            switch (position)
            {
                case 0:
                    cond = "if(" + leftString + " " + compareString + " " + rightString + ")";
                    break;
                case 1:
                    cond = "else if(" + leftString + " " + compareString + " " + rightString + ")";
                    break;
                case 2:
                    cond = "else";
                    break;
            }

            return cond;
        }


        public bool checkCondition()
        {
            bool conditionTrue = false;
            switch (compare)
            {
                case 0:
                    if (leftVal < rightVal)
                    {
                        conditionTrue = true;
                        Debug.Log("Condition is true");
                    }
                    else
                    {
                        conditionTrue = false;
                        Debug.Log("Condition is false");
                    }
                    break;
                case 1:
                    if (leftVal > rightVal)
                    {
                        conditionTrue = true;
                        Debug.Log("Condition is true");
                    }
                    else
                    {
                        conditionTrue = false;
                        Debug.Log("Condition is false");
                    }
                    break;
                case 2:
                    if (leftVal == rightVal)
                    {
                        conditionTrue = true;
                        Debug.Log("Condition is true");
                    }
                    else
                    {
                        conditionTrue = false;
                        Debug.Log("Condition is false");
                    }
                    break;
                case 3:
                    if (leftVal == rightVal)
                    {
                        conditionTrue = true;
                        Debug.Log("Condition is true");
                    }
                    else
                    {
                        conditionTrue = false;
                        Debug.Log("Condition is false");
                    }
                    break;
                case 4:
                    if (leftVal <= rightVal)
                    {
                        conditionTrue = true;
                        Debug.Log("Condition is true");
                    }
                    else
                    {
                        conditionTrue = false;
                        Debug.Log("Condition is false");
                    }
                    break;
                case 5:
                    if (leftVal >= rightVal)
                    {
                        conditionTrue = true;
                        Debug.Log("Condition is true");
                    }
                    else
                    {
                        conditionTrue = false;
                        Debug.Log("Condition is false");
                    }
                    break;
                case 6:
                    if (leftVal != rightVal)
                    {
                        conditionTrue = true;
                        Debug.Log("Condition is true");
                    }
                    else
                    {
                        conditionTrue = false;
                        Debug.Log("Condition is false");
                    }
                    break;
            }

            return conditionTrue;

        }

    }

