﻿using System;
using System.Collections.Generic;

namespace Domore.Collections.ObjectModel {
    public abstract class IndexedDisposableCollection<TIndex, TItem> : IndexedCollection<TIndex, TItem> where TItem : IIndexedItem<TIndex>, IDisposable {
        protected IndexedDisposableCollection() {
        }

        protected IndexedDisposableCollection(IEqualityComparer<TIndex> comparer) : base(comparer) {
        }

        protected virtual void Dispose(bool disposing) {
            if (disposing) {
                var items = Items();
                foreach (var item in items) {
                    item.Dispose();
                }
            }
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~IndexedDisposableCollection() {
            Dispose(false);
        }
    }
}
