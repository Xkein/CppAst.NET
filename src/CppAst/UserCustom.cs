using ClangSharp.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CppAst.CppTokenUtil;

namespace CppAst
{
    public unsafe struct UserCustomParseContext
    {
        public UserCustomParseContext(CppGlobalDeclarationContainer globalContainer, CXCursor cursor, CXCursor parent, void* data)
        {
            GlobalContainer = globalContainer;
            Cursor = cursor;
            Parent = parent;
            Data = data;
        }
        public CppGlobalDeclarationContainer GlobalContainer;
        public CXCursor Cursor;
        public CXCursor Parent;
        public void* Data;
    }
    public static class UserCustom
    {
        public static event Action<UserCustomParseContext, CppMacro> UserParseMacro;
        public static event Action<UserCustomParseContext, CppClass> UserParseClass;
        public static event Action<UserCustomParseContext, CppField> UserParseField;
        public static event Action<UserCustomParseContext, CppFunction> UserParseFunction;
        public static event Action<UserCustomParseContext, CppEnum> UserParseEnum;
        public static event Action<UserCustomParseContext, CppEnumItem> UserParseEnumItem;
        public static event Action<UserCustomParseContext, CppNamespace> UserParseNamespace;
        public static event Action<UserCustomParseContext, CppParameter> UserParseParameter;

        public static event Action<UserCustomParseContext> UserParseOther;

        internal static void UserParseElement<T>(UserCustomParseContext context, T element) where T : CppElement
        {
            if (element == null)
            {
                UserParseOther?.Invoke(context);
            }
            else if (element is CppMacro)
            {
                UserParseMacro?.Invoke(context, element as CppMacro);
            }
            else if (element is CppClass)
            {
                UserParseClass?.Invoke(context, element as CppClass);
            }
            else if (element is CppField)
            {
                UserParseField?.Invoke(context, element as CppField);
            }
            else if (element is CppFunction)
            {
                UserParseFunction?.Invoke(context, element as CppFunction);
            }
            else if (element is CppEnum)
            {
                UserParseEnum?.Invoke(context, element as CppEnum);
            }
            else if (element is CppEnumItem)
            {
                UserParseEnumItem?.Invoke(context, element as CppEnumItem);
            }
            else if (element is CppNamespace)
            {
                UserParseNamespace?.Invoke(context, element as CppNamespace);
            }
            else if (element is CppParameter)
            {
                UserParseParameter?.Invoke(context, element as CppParameter);
            }
            else
            {
                UserParseOther?.Invoke(context);
            }
        }
    }
}
