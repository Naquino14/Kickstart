using System;
using c = System.Console;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace GoogleKickstart
{
    public class HashCodeQualificationRound2022
    {
        static readonly string inputPath = @"\HC22Q i", outputPath = @"\HC22Q i";

        public static void Mainn(string[] args)
        {
            var input = File.ReadAllLines(args[0].Contains(".txt") ? $@"{((args[0].Contains(@"C:\") || args[0].Contains(@"D:\")) ? args[0] : @$"{Directory.GetCurrentDirectory()}{inputPath}\{args[0]}")}" : throw new ArgumentException("Invalid Path."));
            ;

            #region parsing args
            var firstLine = input[0].Split(' ');
            int amtContributors = int.Parse(firstLine[0]), 
                amtProjects = int.Parse(firstLine[1]);

            Contributor[] contributors = new Contributor[amtContributors];
            Project[] projects = new Project[amtProjects];

            int offset = 1;

            #region contributors

            for (int i = 0; i < amtContributors; i++)
            {
                var ctx = input[offset].Split(' ');
                offset++;
                contributors[i] = new();
                contributors[i].Name = ctx[0];
                contributors[i].Skills = new();
                int amtSkills = int.Parse(ctx[1]);
                for (int j = 0; j < amtSkills; j++)
                {
                    var skillCtx = input[offset].Split(' ');
                    offset++;
                    contributors[i].Skills.Add(skillCtx[0], int.Parse(skillCtx[1]));
                }
            }

            #endregion

            #region projects

            for (int i = 0; i < amtProjects; i++)
            {
                var ctx = input[offset].Split(' ');
                offset++;
                projects[i] = new();
                projects[i].ProjectName = ctx[0];
                projects[i].Duration = int.Parse(ctx[1]);
                projects[i].Score = int.Parse(ctx[2]);
                projects[i].BestBefore = int.Parse(ctx[3]);
                projects[i].NumberOfRoles = int.Parse(ctx[4]);
                projects[i].RequiredSkills = new();
                for (int j = 0; j < projects[i].NumberOfRoles; j++)
                {
                    var roleCtx = input[offset].Split(' ');
                    offset++;
                    projects[i].RequiredSkills.Add(roleCtx[0], int.Parse(roleCtx[1]));
                }
            }

            #endregion

            #endregion

            /// assigning priotity:
            /// should be based on 
            /// higher point value
            /// less contributors
            /// less duration
            /// 

            /// priority list:
            /// see desmos
            /// 

            #region create priority list

            // we create a loop for the day
            int day = 0;
            while (!CheckIfProjectsDone(projects))
            {
                for (int i = 0; i < projects.Length; i++)
                {
                    // assign priority
                    if (projects[i].WorkedOn)
                        projects[i].Priority = GetPriority(projects[i], day);

                    // check if a project is finished
                    if (projects[i].Duration == 0)
                    {
                        projects[i].Finished = true;
                        projects[i].WorkedOn = false;
                        for (int j = 0; j < projects[i].NumberOfRoles; j++)
                            if (!ReferenceEquals(projects[i].Contributors, null))
                            {
                                projects[i].Contributors[j].IsBusy = false;
                                // level up the skill if they met criteria
                                if (contributors[j].ContributingSkillLevel >= contributors[j].Skills[contributors[j].ContributingSkill])
                                    contributors[j].Skills[contributors[j].ContributingSkill]++;

                            }
                    }
                }

                // check priorities and assign people

                projects = projects.ToList().OrderByDescending(p => p.Priority).ToArray(); // sort by priority

                // assign people
                ;
                for (int i = 0; i < projects.Length; i++)
                {
                    for (int j = 0; j < contributors.Length; j++)
                    {
                        var contribution = contributors[j].canContribute(projects[i]);
                        if (contribution.canContribute)
                            contributors[j].AssignToProject(ref projects[i], contribution.skill);
                    }
                    if (!ReferenceEquals(projects[i].Contributors, null))
                        if (projects[i].Contributors.Count == projects[i].RequiredSkills.Count)
                            projects[i].WorkedOn = true;

                }


                for (int i = 0; i < projects.Length; i++)
                    if (projects[i].WorkedOn)
                        projects[i].Duration--;
                day++;
            }

            #endregion
            // this didnt work because people were getting assigned to projects that couldnt be started
            // we tried...
        }

        static bool CheckIfProjectsDone(Project[] projects)
        {
            foreach (Project p in projects)
                if (!p.Finished)
                    return false;
            return true;
        }

        static float GetPriority(Project p, int day) // a function to calculate the priority based on the day
        {
            return (p.BestBefore - day - p.Duration + p.Score) / (-1 * p.RequiredSkills.Count);
        }
    }

    public class Project
    {
        public string ProjectName { get; set; }
        public Dictionary<string, int> RequiredSkills { get; set; }
        public List<Contributor> Contributors { get; set; }
        public int Duration { get; set; }
        public int Score { get; set; }
        public int BestBefore { get; set; }
        public int NumberOfRoles { get; set; }
        public float Priority { get; set; }
        public bool Finished { get; set; }
        public bool WorkedOn { get; set; }
    }

    public class Contributor
    {
        public string Name { get; set; }
        public Dictionary<string, int> Skills { get; set; }
        public int DaysBusy { get; set; }
        public Project CurrentProject { get; set; }
        public bool IsBusy { get; set; }
        public string ContributingSkill { get; set; }
        public int ContributingSkillLevel { get; set; }

        public (bool canContribute, string skill) canContribute(Project project)
        {
            if (DaysBusy == 0)
                foreach (string skill in Skills.Keys)
                    if (project.RequiredSkills.ContainsKey(skill) && project.RequiredSkills[skill] <= Skills[skill])
                        return (true, skill);
                    else
                        continue;
            return (false, "");
        }

        public bool isQualified(string requiredSkill, int requiredLevel)
        {
            return Skills.ContainsKey(requiredSkill) && Skills[requiredSkill] >= requiredLevel;
        }

        public bool canMentor(string mentorSkill, int requiredLevel, Project project)
        {
            return Skills.ContainsKey(mentorSkill) && Skills[mentorSkill] >= requiredLevel && CurrentProject.ProjectName == project.ProjectName;
        }

        public void AssignToProject(ref Project p, string skill)
        {
            DaysBusy = p.Duration;
            CurrentProject = p;
            IsBusy = true;
            ContributingSkill = skill;
            ContributingSkillLevel = p.RequiredSkills[ContributingSkill];
            p.Contributors ??= new();
            p.Contributors.Add(this);
            p.RequiredSkills.Remove(skill);
        }
    }
}
