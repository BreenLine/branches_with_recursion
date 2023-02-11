// See https://aka.ms/new-console-template for more information


class Branch
{
    public string Name { get; set; }
    public List<Branch> Branches { get; set; }

    public Branch(string name)
    {
        this.Name = name;
        this.Branches = new List<Branch>();
    }

    public void AddBranch(Branch branch)
    {
        this.Branches.Add(branch);
    }
}

class Program
{
    static int CalculateDepth(Branch branch, int depth)
    {
        int maxDepth = depth;

        foreach (Branch child in branch.Branches)
        {
            int childDepth = CalculateDepth(child, depth + 1);
            if (childDepth > maxDepth)
            {
                maxDepth = childDepth;
            }
        }

        return maxDepth;
    }

    static void Main(string[] args)
    {
        Branch root = new Branch("Root");
        Branch r1 = new Branch("R1");
        Branch r11 = new Branch("R11");
        Branch r2 = new Branch("R2");
        Branch r21 = new Branch("R21");
        Branch r211 = new Branch("R211");
        Branch r22 = new Branch("R22");
        Branch r221 = new Branch("R221");
        Branch r2211 = new Branch("R2211");
        Branch r222 = new Branch("R222");
        Branch r23 = new Branch("R23");

        root.AddBranch(r1);
        root.AddBranch(r2);
        r1.AddBranch(r11);
        r2.AddBranch(r21);
        r2.AddBranch(r22);
        r21.AddBranch(r211);
        r22.AddBranch(r221);
        r22.AddBranch(r222);
        r221.AddBranch(r2211);
        r2.AddBranch(r23);

        int depth = CalculateDepth(root, 1);
        Console.WriteLine("Depth of the tree: " + depth);
    }
}

