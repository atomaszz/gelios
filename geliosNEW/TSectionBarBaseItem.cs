using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geliosNEW
{
    public class TSectionBarBaseItem
    {
        private string  FHint;
        private string FCaption;
        private bool FVisible;
        private bool FEnabled;
        private int FTag;
        private void  SetCaption (string ACaption)
        {
            if (ACaption != FCaption)
            {
                FCaption = ACaption;
                Changed();
            }
        }
        public virtual void  SetTag (int Value)
        {
            if (FTag != Value)
            {
                FTag = Value;
                Changed();
            }
        }
        protected string GetDisplayName()
        {
            return Caption;
        }
        public virtual void SetVisible(bool AVisible)
        {
            if (AVisible != FVisible)
            {
                FVisible = AVisible;
                Changed();
            }
        }
        public virtual void SetEnabled(bool AEnabled)
        {
            if (AEnabled != FEnabled)
            {
                FEnabled = AEnabled;
                Changed();
            }
        }
        public virtual void Changed()
        {
            /*I don't know what is this */
           /* TSectionBarBaseCollection* C;
            C = dynamic_cast<TSectionBarBaseCollection*>(Collection);
            if (C) C->Changed();*/
        }
        public virtual void InitProperties()
        {
            FCaption = "";
            FVisible = true;
            FEnabled = true;
        }

        public void  Assign()
        {
         /*   TSectionBarBaseItem* C;
            TCollectionItem::Assign(Source);
            C = dynamic_cast<TSectionBarBaseItem*>(Source);
            if (C)
            {
                Caption = C->Caption;
                Visible = C->Visible;
                Enabled = C->Enabled;
                Tag = C->Tag;
            }*/
        }
        public TSectionBarBaseItem()
        {
            InitProperties();
            Changed();
        }
        //      ~TSectionBarBaseItem();

        public bool Visible
        {
            get { return FVisible; }
            set
            {
                 SetVisible(value);
            }
        }
        public bool Enabled
        {
            get { return FEnabled; }
            set
            {
                 SetEnabled(value);
            }
        }
        public string Caption
        {
            get { return FCaption; }
            set
            {
                 SetCaption(value);
            }
        }
        public int Tag
        {
            get { return FTag; }
            set
            {
                 SetTag(value);
            }
        }
        public string Hint { get; set; }
    }
}
