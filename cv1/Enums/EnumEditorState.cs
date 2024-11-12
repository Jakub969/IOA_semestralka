using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv1.Enums
{
    public enum EnumEditorState
    {
        None = 0,
        InsertNode, 
        InsertEdge, 
        SelectBegin, 
        Selecting, 
        PossibleDrag,
        NodeDragging
    }
}
