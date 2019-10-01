using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geliosNEW
{
    public class TSectionBarButton :  TSectionBarBaseItem
    {
        /*----------private------------------------*/
        private bool FSelected;
        private bool FDown;
        private int FImageIndex;
        private int FTag1, FTag2;
        private void SetImageIndex(int AImageIndex)
        {
            if (AImageIndex != FImageIndex)
            {
                FImageIndex = AImageIndex;
                Changed();
            }
        }
        private void SetSelected(bool Value)
        {
  /*          TSectionBarButton LastSelected;
            TSectionBarButtons SBB;
            TSectionBarSections SBS;
            if ((Value) && (!Enabled)) return;
            if ((Value != FSelected) && (Collection))
            {
                SBB = dynamic_cast<TSectionBarButtons*>(Collection);
                SBS = dynamic_cast<TSectionBarSections*>(SBB->FSection->Collection);
                if ((Value) && (SBB->FSection) && (SBB->FSection->Collection) && (SBS->FSectionBar))
                {
                    LastSelected = SBS->FSectionBar->Selected;
                    if (LastSelected) LastSelected->Selected = false;
                }
                else
                    SBB->ButtonChanging(this);

                FSelected = Value;
                if (FSelected) MakeVisible();

                if ((FSelected) && (Collection))
                    SBB->ButtonChanged(this);
                Changed();
            }*/
        } //NOT REALISED
        private void SetDown(bool Value)
        {
            /*           TSectionBarButton LastDown;
                       TSectionBarButtons SBB;
                       TSectionBarSections SBS;
                       if ((Value) && (!Enabled)) return;
                       if ((Value != FDown) && (Collection))
                       {
                           SBB = dynamic_cast<TSectionBarButtons*>(Collection);
                           SBS = dynamic_cast<TSectionBarSections*>(SBB->FSection->Collection);
                           if ((Value) && (SBB->FSection) && (SBB->FSection->Collection) && (SBS->FSectionBar))
                           {
                               LastDown = SBS->FSectionBar->Down;
                               if (LastDown) LastDown->Down = false;
                           }
                           else
                               SBB->ButtonChanging(this);

                           FDown = Value;
                           if (FDown) MakeVisible();

                           if ((FDown) && (Collection))
                               SBB->ButtonChanged(this);
                           Changed();
                       }*/
        } //NOT REALISED 

        /*----------protected--------------------*/
        protected void SetVisible(bool AVisible)
        {
            if ((Selected) && (!AVisible)) return;
            base.SetVisible(AVisible);
        }
        protected void SetEnabled(bool AEnabled)
        {
            if ((Selected) && (!AEnabled)) return;
            base.SetEnabled(AEnabled);
        }
        protected void InitProperties()
        {
            base.InitProperties();
            Caption = "Новая кнопка";
            FSelected = false;
            FDown = false;
            FTag1 = 0;
            FTag2 = 0;
            FImageIndex = -1;
        }

        /*----------public----------------------*/
        //      partial void Assign();
     ///   public void MakeVisible();

        public int ImageIndex
        {
            get { return FImageIndex; }
            set
            {
                SetImageIndex (value);
            }
        }
        public bool Selected
        {
            get { return FSelected; }
            set
            {
                SetSelected(value);
            }
        }
        public bool Down
        {
            get { return FDown; }
            set
            {
                SetDown(value);
            }
        }
        public int Tag1 { get; set; }
        public int Tag2 { get; set; }
    }
}
