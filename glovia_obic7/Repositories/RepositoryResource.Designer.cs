﻿//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.42000
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

namespace glovia_obic7.Repositories {
    using System;
    
    
    /// <summary>
    ///   ローカライズされた文字列などを検索するための、厳密に型指定されたリソース クラスです。
    /// </summary>
    // このクラスは StronglyTypedResourceBuilder クラスが ResGen
    // または Visual Studio のようなツールを使用して自動生成されました。
    // メンバーを追加または削除するには、.ResX ファイルを編集して、/str オプションと共に
    // ResGen を実行し直すか、または VS プロジェクトをビルドし直します。
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class RepositoryResource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal RepositoryResource() {
        }
        
        /// <summary>
        ///   このクラスで使用されているキャッシュされた ResourceManager インスタンスを返します。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("glovia_obic7.Repositories.RepositoryResource", typeof(RepositoryResource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   厳密に型指定されたこのリソース クラスを使用して、すべての検索リソースに対し、
        ///   現在のスレッドの CurrentUICulture プロパティをオーバーライドします。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   - に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string MinusSignString {
            get {
                return ResourceManager.GetString("MinusSignString", resourceCulture);
            }
        }
        
        /// <summary>
        ///   正の整数である必要があります。 に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string MustPositiveNumber {
            get {
                return ResourceManager.GetString("MustPositiveNumber", resourceCulture);
            }
        }
        
        /// <summary>
        ///   NULLは指定できません。 に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string NullExceptionMessage {
            get {
                return ResourceManager.GetString("NullExceptionMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   桁数オーバーです。 に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string OverflowMessage {
            get {
                return ResourceManager.GetString("OverflowMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   size に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string ParamaterName_size {
            get {
                return ResourceManager.GetString("ParamaterName_size", resourceCulture);
            }
        }
        
        /// <summary>
        ///   src に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string ParamaterName_src {
            get {
                return ResourceManager.GetString("ParamaterName_src", resourceCulture);
            }
        }
        
        /// <summary>
        ///   shift_jis に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string ReadFileEncod {
            get {
                return ResourceManager.GetString("ReadFileEncod", resourceCulture);
            }
        }
    }
}
