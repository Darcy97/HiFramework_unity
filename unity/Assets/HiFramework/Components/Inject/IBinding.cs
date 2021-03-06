﻿/***************************************************************
 * Description: 
 *
 * Documents: 
 * Author: hiramtan@live.com
***************************************************************/

namespace HiFramework
{
    public interface IBinding
    {
        /// <summary>
        /// Bind to a instance 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        IBindAsName To(object args);
    }
}
