using System;

namespace BlazorApp.Shared
{
    public class PageInfo
    {
        int pageCount;
        int currentPage;

        public int PageCount
        {
            get => pageCount;
            set
            {
                pageCount = value;
                SetButtonsValue();
            }
        }

        public int PageSize { get; set; }
        public int CurrentPage 
        {
            get => currentPage;
            set
            {
                currentPage = value;
                SetButtonsValue();
            }
        }

        public int TotalCount { get; set; }
        public Action<int> NaviToPage { get; set; }
        public int ShowPagesButtonCount { get; set; } = 8;
        public int PageOffset => ShowPagesButtonCount / 2;
        public int LeftButtonShowCount { get; set; }
        public int RightButtonShowCount { get; set; }

        public override string ToString()
        {
            return $"ShowPagesButtonCount {ShowPagesButtonCount} LeftButtonShowCount {LeftButtonShowCount} RightButtonShowCount {RightButtonShowCount} PageOffset {PageOffset} CurrentPage {CurrentPage}";
        }

        void SetButtonsValue()
        {
            if(CurrentPage - 1 < PageOffset)
            {
                LeftButtonShowCount = CurrentPage - 1;
                RightButtonShowCount = ShowPagesButtonCount - LeftButtonShowCount;
            }
            else if(PageCount - CurrentPage - 1 < PageOffset)
            {
                RightButtonShowCount = PageCount - CurrentPage - 1;
                LeftButtonShowCount = ShowPagesButtonCount - RightButtonShowCount;
            }
            else
            {
                LeftButtonShowCount = RightButtonShowCount = PageOffset;
            }
        }
    }
}
