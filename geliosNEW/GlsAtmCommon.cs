using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geliosNEW
{
    class TGlsNode
    {
        protected TGlsNode _next;
        protected TGlsNode _prev;
        public TGlsNode()
        {
            _next = this;
            _prev = this;
        }
             ~TGlsNode() { }
      /*      public TGlsNode insert(TGlsNode ANode);
            public TGlsNode remove();
            public void splice(TGlsNode b);

            public TGlsNode Next = {read = _next, write = _next

            public TGlsNode Prev = { read = _prev, write = _prev };*/
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
    class TGlsList : TGlsNode
    {
        TGlsListNode header;
        TGlsListNode win;
        int _length;

        /*     public TGlsList();
             ~TGlsList() { }
             public void* insert(void* T);
             public void* append(void* T);
             public TpublicGlsList* append(TGlsList* T);
             public void* prepend(void* T);
             public void* remove();
             public void val(void* T);
             public void* val();
             public void* next();
             public void* prev();
             public void* first();
             public void* last();
             public int length();
             public bool isFirst();
             public bool isLast();
             public bool isHead();
             public void clear();*/
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
        TGlsBTreeNode _lchild;
        TGlsBTreeNode _rchild;
        object _val;
        public TGlsBTreeNode(object T)
        {
            base.TGlsNode();
            _val = T;
            _lchild = null;
            _rchild = null;
        }
        ~TGlsBTreeNode() { }
    /*         public object Val = { read = _val, write = _val };
             public TGlsBTreeNode lchild = { read = _lchild, write = _lchild };
             public TGlsBTreeNode rchild = { read = _rchild, write = _rchild };*/
    }
    class TGlsBinaryTree
    {
        public delegate int TCmp (object a, object b);

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
              public void* findMax();
              public void inorder(bool (*) (void*));
              public void* insert(void* T);
              public  void* next();
              public void* prev();
              public void* first();
              public void* last();
              public void* val();*/
    }
}
