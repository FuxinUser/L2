using System.Drawing;

namespace L2
{
    public interface IServerUI
    {
        void ChangeBindTooltip(string tooltip, Color color);
        void ChangeConnTooltip(string tooltip, Color color);
        void SetSubmitBtn(bool enable);
        void InsertLog(string text, object tag = null);
    }
}
