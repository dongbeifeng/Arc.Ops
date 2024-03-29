﻿// Copyright 2022 王建军
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


using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace Arc.Ops.Mappings;

internal class OpMapping : ClassMapping<Op>
{
    public OpMapping()
    {
        Table("Ops");
        DynamicUpdate(true);
        BatchSize(10);
        Mutable(false);

        Id(cl => cl.OpId, id => id.Generator(Generators.Identity));

        Property(cl => cl.CreationTime);
        Property(cl => cl.CreationUser);
        Property(cl => cl.OperationType);
        Property(cl => cl.Url);
        Property(cl => cl.IPAddress);

        Property(cl => cl.Comment);
    }
}
