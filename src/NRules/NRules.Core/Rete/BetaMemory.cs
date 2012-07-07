﻿using System.Collections.Generic;

namespace NRules.Core.Rete
{
    internal class BetaMemory : ITupleSink, ITupleMemory
    {
        private readonly List<Tuple> _tuples = new List<Tuple>();
        private ITupleSink _sink;

        public BetaMemory(ITupleSource source)
        {
            source.Attach(this);
        }

        public void PropagateAssert(Tuple tuple)
        {
            _tuples.Add(tuple);
            _sink.PropagateAssert(tuple);
        }

        public IEnumerable<Tuple> GetTuples()
        {
            return _tuples;
        }

        public void Attach(ITupleSink sink)
        {
            _sink = sink;
        }
    }
}