namespace SalmonEmulator
{
    public abstract class SyntaxNode { } // holds either LableNode's or InstructionBlockNode's

    public class InstructionBlockNode : SyntaxNode 
    {
        // optionally holds numeric, address, and register nodes, possibly multipler of each
        public List<InstructionBlockNode> Nodes { get; set; } = new List<InstructionBlockNode>();
    }

    public class LableNode : SyntaxNode
    {
        // holds naming, and line number data
        public string? Lable { get; set; }
        public string? Line { get; set; }

    }
    public class InstructionNode : InstructionBlockNode
    {
        // holds a string like "li"
        public string? Instruction {  get; set; }
    }

    public class NumericNode : InstructionBlockNode
    {
        // holds a string like "0b1010"
        public string? Numeric { get; set; }
    }
    public class AddressNode : InstructionBlockNode
    {
        // holds a string like "[0xff01]"
        public string? Address { get; set; }
    }

    public class RegisterNode : InstructionBlockNode
    {
        // holds a string like "r0"
        public string? Register { get; set; }
    }
}
