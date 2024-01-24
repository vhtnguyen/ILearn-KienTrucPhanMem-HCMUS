using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp45
{
    internal class MyCompositeFunction : MyFunction
    {

        public List<MyProgramStep> steps = new List<MyProgramStep>();
        private VariableDictionary globalVariables = new VariableDictionary();

        private void ResetVariables()
        {
            globalVariables.variables.Clear();
        }

        private void CopyVariableValues(VariableDictionary source,
            VariableDictionary target, List<VariableMapping> mappings)
        {
            for (int i = 0; i < mappings.Count; i++)
            {
                target[mappings[i].strTargetVariableName]
                    = source[mappings[i].strSourceVariableName];
            }
        }

        public override VariableDictionary Execute(VariableDictionary inputFromOutsider)
        {
            ResetVariables();
            // Sao chép mọi thứ được đưa vào trong globalVariables
            globalVariables = inputFromOutsider;
            VariableDictionary input, output;
            for (int i = 0; i < steps.Count; i++)
            {
                // sao chép từ globalVariables sang input theo quy tắc ánh xạ steps[i].inputmapping
                input = PrepareInput(steps[i]);
                output = steps[i].Execute(input);
                // sao chép từ output sang globalVariables theo quy tắc ánh xạ steps[i].outputmapping
                CollectOutput(output, steps[i]);
            }
            return globalVariables;
        }

        private void CollectOutput(VariableDictionary output, MyProgramStep myProgramStep)
        {
            CopyVariableValues(output, globalVariables, myProgramStep.outputmapping);
        }

        private VariableDictionary PrepareInput(MyProgramStep myProgramStep)
        {
            VariableDictionary res = new VariableDictionary();
            CopyVariableValues(globalVariables, res, myProgramStep.inputmapping);
            return res;
        }

        internal void DisplayAllVariables()
        {
            foreach (string sName in globalVariables.variables.Keys)
            {
                Console.WriteLine(sName + " = " + globalVariables[sName]);
            }
        }

        internal bool LoadProgramFromScript(string strFileName)
        {
            StreamReader sr = new StreamReader(strFileName);
            MyProgramStep step;
            int nSteps = int.Parse(sr.ReadLine());
            for (int i = 0; i < nSteps; i++)
            {
                step = ReadStep(sr);
                steps.Add(step);
            }

            sr.Close();
            return true;

        }

        private MyProgramStep ReadStep(StreamReader sr)
        {
            MyProgramStep res = new MyProgramStep();
            res.strFunctionName = sr.ReadLine();

            res.inputmapping = ReadMappings(sr);
            res.outputmapping = ReadMappings(sr);
            return res;
        }

        private List<VariableMapping> ReadMappings(StreamReader sr)
        {
            // 1 v1 a
            // 2 b v1 c v2
            string s = sr.ReadLine();
            string[] tokens = s.Split(' ');
            int n = int.Parse(tokens[0]);
            List<VariableMapping> mappings = new List<VariableMapping>();
            for (int i = 0; i < n; i++)
            {
                mappings.Add(new VariableMapping(tokens[2 * i + 1], tokens[2 * i + 2]));
            }
            return mappings;
        }
    }
}