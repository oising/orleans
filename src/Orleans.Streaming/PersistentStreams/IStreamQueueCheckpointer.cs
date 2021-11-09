﻿using System;
using System.Threading.Tasks;

namespace Orleans.Streams
{
    public interface IStreamQueueCheckpointerFactory
    {
        Task<IStreamQueueCheckpointer<string>> Create(string partition);
    }

    public interface IStreamQueueCheckpointer<TCheckpoint>
    {
        bool CheckpointExists { get; }
        Task<TCheckpoint> Load();
        Task Reset() => throw new NotSupportedException();
        void Update(TCheckpoint offset, DateTime utcNow);
    }
}
