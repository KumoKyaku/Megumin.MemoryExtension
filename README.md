# Megumin.MemoryExtension

System.Memory.dll扩展。

- 增加一个BufferPool，支持租用托管和非托管内存。  
  + 与`MemoryPool<T> Shared`不同，Memory的长度与申请长度相同。
  + 租用获得的内存已经清零。
  
- 扩展`Span<byte>` write/read， 使用小端包装值类型操作。
- 增加SpanStream。方便与其他库流式API兼容。