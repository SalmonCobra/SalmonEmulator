namespace SalmonEmulator;

public static class Ram
{
    private static int[] _memory = new int[1024];
    public static int[] memory => _memory;
}