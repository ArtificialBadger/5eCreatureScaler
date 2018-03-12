using System;
using System.Collections.Generic;
using System.Linq;

namespace CreatureScaler.Platform
{
    public sealed class Choice<T>
    {
        Action<Choice<T>> selectFunc;

        private Choice(T item, Action<Choice<T>> selectFunc)
        {
            Item = item;
            this.selectFunc = selectFunc;
        }

        public T Item { get; }

        public void Choose()
        {
            selectFunc(this);
        }

        public sealed class Set
        {
            private List<Choice<T>> selections;
            private Choice<T> selected;

            public Set(IEnumerable<T> items)
            {
                this.selections = items.Select(item => new Choice<T>(item, Select)).ToList();
            }

            public bool Accepted { get; private set; } = false;
            public bool Rejected { get; private set; } = false;

            public IReadOnlyList<Choice<T>> PossibleSelections => selections;
            public T SelectedItem => selected.Item;

            public void Reject()
            {
                selected = null;
                Accepted = false;
                Rejected = true;
            }

            private void Select(Choice<T> selected)
            {
                this.selected = selected;
                Accepted = true;
                Rejected = false;
            }
        }
    }
}
