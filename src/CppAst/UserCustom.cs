using ClangSharp.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CppAst.CppTokenUtil;

namespace CppAst
{
    public static class UserCustom
    {
        public static event Action<CXCursor, CXCursor, CppMacro> UserParseMacro;
        public static event Action<CXCursor, CXCursor, CppClass> UserParseClass;
        public static event Action<CXCursor, CXCursor, CppField> UserParseField;
        public static event Action<CXCursor, CXCursor, CppFunction> UserParseFunction;
        public static event Action<CXCursor, CXCursor, CppEnum> UserParseEnum;
        public static event Action<CXCursor, CXCursor, CppEnumItem> UserParseEnumItem;
        public static event Action<CXCursor, CXCursor, CppNamespace> UserParseNamespace;
        public static event Action<CXCursor, CXCursor, CppParameter> UserParseParameter;

        public static event Action<CXCursor, CXCursor> UserParseOther;

        internal static void UserParseElement<T>(CXCursor cursor, CXCursor parent, T element) where T : CppElement
        {
            if (element == null)
            {
                UserParseOther?.Invoke(cursor, parent);
            }
            else if (element is CppMacro)
            {
                UserParseMacro?.Invoke(cursor, parent, element as CppMacro);
            }
            else if (element is CppClass)
            {
                UserParseClass?.Invoke(cursor, parent, element as CppClass);
            }
            else if (element is CppField)
            {
                UserParseField?.Invoke(cursor, parent, element as CppField);
            }
            else if (element is CppFunction)
            {
                UserParseFunction?.Invoke(cursor, parent, element as CppFunction);
            }
            else if (element is CppEnum)
            {
                UserParseEnum?.Invoke(cursor, parent, element as CppEnum);
            }
            else if (element is CppEnumItem)
            {
                UserParseEnumItem?.Invoke(cursor, parent, element as CppEnumItem);
            }
            else if (element is CppNamespace)
            {
                UserParseNamespace?.Invoke(cursor, parent, element as CppNamespace);
            }
            else if (element is CppParameter)
            {
                UserParseParameter?.Invoke(cursor, parent, element as CppParameter);
            }
            else
            {
                UserParseOther?.Invoke(cursor, parent);
            }
        }
    }
}
