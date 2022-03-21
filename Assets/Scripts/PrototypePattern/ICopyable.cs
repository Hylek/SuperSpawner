namespace PrototypePattern
{
    public interface ICopyable
    {
        ICopyable Copy();
        void Activate();
        void DeActivate();
    }
}