﻿using System;
using System.Collections.Generic;
using Gravity.Base;
using Gravity.Utils;
using Relativity.API;

namespace Gravity.DAL.SQL
{
	public partial class SqlDao : IGravityDao
	{
		private const int _defaultBatchSize = 1000;

		protected int workspaceId;
		protected IDBContext dbContext;
		protected IDBContext masterDbContext;
		protected int batchSize;

		private InvokeWithRetryService invokeWithRetryService;

		public SqlDao(IDBContext workspaceContext, IDBContext masterContext, int workspaceId,
			InvokeWithRetrySettings invokeWithRetrySettings = null,
			int batchSize = _defaultBatchSize)
		{
			dbContext = workspaceContext;
			masterDbContext = masterContext;
			this.workspaceId = workspaceId;
			invokeWithRetryService = InvokeWithRetryService.GetInvokeWithRetryService(invokeWithRetrySettings);
			batchSize = _defaultBatchSize;
		}

		public SqlDao(IHelper helper, int workspaceId,
			InvokeWithRetrySettings invokeWithRetrySettings = null,
			int batchSize = _defaultBatchSize)
			: this(helper.GetDBContext(workspaceId), helper.GetDBContext(-1), workspaceId, invokeWithRetrySettings, batchSize)
		{ }

		#region SQL Dao Not Implemented operations

		[Obsolete("SQL Dao Insert is not implemented yet.", true)]
		public int Insert<T>(T obj, ObjectFieldsDepthLevel depthLevel)
			where T : BaseDto => throw new NotImplementedException();

		[Obsolete("SQL Dao Bulk Insert is not implemented yet.", true)]
		public void Insert<T>(IList<T> objs, ObjectFieldsDepthLevel depthLevel)
			where T : BaseDto => throw new NotImplementedException();

		[Obsolete("SQL Dao Update is not implemented yet.", true)]
		public void Update<T>(T obj, ObjectFieldsDepthLevel depthLevel)
			where T : BaseDto => throw new NotImplementedException();

		[Obsolete("SQL Dao Bulk Update is not implemented yet.", true)]
		public void Update<T>(IList<T> objs, ObjectFieldsDepthLevel depthLevel)
			where T : BaseDto => throw new NotImplementedException();

		[Obsolete("SQL Dao Delete is not implemented yet.", true)]
		public void Delete<T>(int artifactID, ObjectFieldsDepthLevel depthLevel)
			where T : BaseDto, new() => throw new NotImplementedException();

		[Obsolete("SQL Dao Bulk Delete is not implemented yet.", true)]
		public void Delete<T>(IList<int> artifactIDs, ObjectFieldsDepthLevel depthLevel)
			where T : BaseDto, new() => throw new NotImplementedException();

		#endregion
	}
}
