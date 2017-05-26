////////////////////////////////////////////////////////////////////////////
//
// Copyright 2017 Rubius
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
////////////////////////////////////////////////////////////////////////////

using System;
using System.IO;
using System.Threading.Tasks;
using Plugin.NetStandardStorage;
using Plugin.NetStandardStorage.Abstractions.Types;

namespace Realmius.Infrastructure
{
    public class FileExtensions2
    {
        public static async Task<string> CopyFileToUserLocation(string path)
        {
            var sourceFile = CrossStorage.FileSystem.GetFileFromPath(path);
            var newFileName = Guid.NewGuid() + Path.GetExtension(path);
            var newFile =
                CrossStorage.FileSystem.LocalStorage.CreateFile(newFileName, CreationCollisionOption.ReplaceExisting);

            using (var writeStream = newFile.Open(FileAccess.ReadWrite))
            {
                using (var sourceStream = sourceFile.Open(FileAccess.Read))
                {
                    sourceStream.CopyTo(writeStream);
                    writeStream.Flush();
                }
            }

            return newFile.FullPath;
        }
    }
}