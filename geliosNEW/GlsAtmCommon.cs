using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geliosNEW
{
    public class TGlsNode
    {
        protected TGlsNode _next;
        protected TGlsNode _prev;
        public TGlsNode()
        {
            _next = this;
            _prev = this;
        }
        public void TGlsNode1()
        {
            _next = this;
            _prev = this;
        }
        ~TGlsNode() { }
        public TGlsNode insert(TGlsNode ANode)
        {
            TGlsNode c = _next;
            ANode._next = c;
            ANode._prev = this;
            _next = ANode;
            c._prev = ANode;
            return ANode;
        }
        public TGlsNode remove()
        {
            _prev._next = _next;
            _next._prev = _prev;
            _next = _prev = this;
            return this;
        }
        public void splice(TGlsNode b)
        {
            TGlsNode a = this;
            TGlsNode an = a._next;
            TGlsNode bn = b._next;
            a._next = bn;
            b._next = an;
            an._prev = b;
            bn._prev = a;
        }


        public TGlsNode Next
        {
            set { _next = value; }
            get { return _next; }
        }
            
        public TGlsNode Prev
        {
            set { _prev = value; }
            get { return _prev; }
        }
    }
    class TGlsListNode : TGlsNode
    {
     object _val;
        public TGlsListNode(object AVal) { _val = AVal; }
        public object Val
        {
            set { _val = value; }
            get { return _val; }
        }
    }
    public class TGlsList : TGlsNode
    {
        TGlsListNode header;
        TGlsListNode win;
        int _length;
        public TGlsList()
        {
            header = new TGlsListNode(null);
            win = header;
            _length = 0;
        }
        ~TGlsList() { }
         /*    public void* insert(void* T);*/
        public object append(object T)
        {
            header.Prev.insert(new TGlsListNode(T));
            ++_length;
            return T;
        }
        public TGlsList append(TGlsList T)
        {
            TGlsListNode a = (TGlsListNode)(header.Prev);
            a.splice(T.header);
            _length += T._length;
            T.header.remove();
            T._length = 0;
            T.win = header;
            return this;
        }
        /*     public void* prepend(void* T);
             public void* remove();
             public void val(void* T);*/
        public object val()
        {
            return win.Val;
        }
        public object next()
        {
            win = (TGlsListNode)(win.Next);
            return win.Val;
        }
        public object prev()
        {
            win = (TGlsListNode)(win.Prev);
            return win.Val;
        }
        public object first()
        {
            win = new TGlsListNode(header.Next);
            return win.Val;
        }
        /*    public void* last();*/
        public int length()
        {
            return _length;
        }
        /*       public bool isFirst();
               public bool isLast();
               public bool isHead();*/
        public void clear()
        {
            while (length() > 0)
            {
                first();
                remove();
            }
        }
    }
    class TGlsStack
    {
     TGlsList s;
        /*      public TGlsStack();
          ~TGlsStack() { }
              public void push(void* T);
              public void* pop();
              public bool empty();
              public int size();
              public void* top();
              public void* nextToTop();
              public void* bottom();*/
    }
    class TGlsBTreeNode :  TGlsNode
    {
        bool bIsRoot;
        TGlsBTreeNode _lchild;
        TGlsBTreeNode _rchild;
        object _val;
        public TGlsBTreeNode(object T)
        {
            base.TGlsNode1();
            _val = T;
            _lchild = null;
            _rchild = null;
            bIsRoot = true;
        }
        ~TGlsBTreeNode() { }
        public object Val
        {
            set { _val = value;  }
            get { return _val;   }
        }
        public TGlsBTreeNode lchild
        {
            set { _lchild = value; }
            get { return _lchild; }
        }
        public TGlsBTreeNode rchild
        {
            set { _rchild = value; }
            get { return _rchild; }
        }
    }
    class TGlsBinaryTree
    {
        public delegate int TCmp (object a, object b);
        public delegate bool acp(object a);

        TGlsBTreeNode root;
        TGlsBTreeNode win;
        TCmp cmp;
        /*  TGlsBTreeNode _findMin(TGlsBTreeNode n);
          TGlsBTreeNode _findMax(TGlsBTreeNode n);*/
        public TGlsBinaryTree(TCmp ACmp)
        {
            cmp = ACmp;
            win = root = new TGlsBTreeNode(null);
        }
        ~TGlsBinaryTree() { }
        /*         public bool isEmpty();
                 public void* find(void* T);
                 public void* findMin();
                 public void* findMax();*/
        public void inorder(acp acpp)
        {
            TGlsBTreeNode n = (TGlsBTreeNode)(root.Next);
            while (n != root)
            {
                if (!(acpp(n.Val))) break;
                n = (TGlsBTreeNode)(n.Next);
            }
        }
        public object insert(object T)
        {
            int res = 1;
            TGlsBTreeNode p = root;
            TGlsBTreeNode n = root.rchild;
            while (n!=null)
            {
                p = n;
                res = cmp(T, p.Val);
                if (res <= 0)
                    n = p.lchild;
                else
                    n = p.rchild;
            }
            win = new TGlsBTreeNode(T);
            if (res <= 0)
            {
                p.lchild = win;
                p.Prev.insert(win);
            }
            else
            {
                p.rchild = win;
                p.insert(win);
            }
            return T;
        }
        /*    public  void* next();
            public void* prev();
            public void* first();
            public void* last();
            public void* val();*/
    }
}
