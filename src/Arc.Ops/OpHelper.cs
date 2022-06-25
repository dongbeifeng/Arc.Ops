// Copyright 2022 王建军
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.


using NHibernate;

namespace Arc.Ops;

/// <summary>
/// 创建操作记录的帮助程序。
/// </summary>
public class OpHelper
{
    ISession _session;

    public OpHelper(ISession session)
    {
        _session = session;
    }

    /// <summary>
    /// 创建并保存操作记录。
    /// </summary>
    /// <param name="controller"></param>
    /// <param name="format">用于填充 <see cref="Op.Comment"/> 属性的格式化字符串。</param>
    /// <param name="args">用于填充 <see cref="Op.Comment"/> 属性的格式化参数。</param>
    /// <returns></returns>
    public async Task<Op> SaveOpAsync(string operationType, string? url, string? ipAddress, string format, params object?[] args)
    {
        Op op = new Op();
        op.OperationType = operationType;
        op.Comment = string.Format(format, args);
        op.Url = url;
        op.IPAddress = ipAddress;
        await _session.SaveAsync(op).ConfigureAwait(false);

        return op;
    }

}