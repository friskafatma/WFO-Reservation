﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EmployeeApi
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="DB_TEST")]
	public partial class DB_EMPLOYEEDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertTBL_KARY(TBL_KARY instance);
    partial void UpdateTBL_KARY(TBL_KARY instance);
    partial void DeleteTBL_KARY(TBL_KARY instance);
        #endregion

        public DB_EMPLOYEEDataContext() :
                base(global::System.Configuration.ConfigurationManager.ConnectionStrings["DB_TESTConnectionString"].ConnectionString, mappingSource)
        {
            OnCreated();
        }

        public DB_EMPLOYEEDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DB_EMPLOYEEDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DB_EMPLOYEEDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<TBL_KARY> TBL_KARies
		{
			get
			{
				return this.GetTable<TBL_KARY>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.TBL_KARY")]
	public partial class TBL_KARY : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _nrp;
		
		private string _nama;
		
		private string _dept;
		
		private string _gender;
		
		private string _alamat;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnnrpChanging(string value);
    partial void OnnrpChanged();
    partial void OnnamaChanging(string value);
    partial void OnnamaChanged();
    partial void OndeptChanging(string value);
    partial void OndeptChanged();
    partial void OngenderChanging(string value);
    partial void OngenderChanged();
    partial void OnalamatChanging(string value);
    partial void OnalamatChanged();
    #endregion
		
		public TBL_KARY()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_nrp", DbType="VarChar(6) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string nrp
		{
			get
			{
				return this._nrp;
			}
			set
			{
				if ((this._nrp != value))
				{
					this.OnnrpChanging(value);
					this.SendPropertyChanging();
					this._nrp = value;
					this.SendPropertyChanged("nrp");
					this.OnnrpChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_nama", DbType="VarChar(MAX)")]
		public string nama
		{
			get
			{
				return this._nama;
			}
			set
			{
				if ((this._nama != value))
				{
					this.OnnamaChanging(value);
					this.SendPropertyChanging();
					this._nama = value;
					this.SendPropertyChanged("nama");
					this.OnnamaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_dept", DbType="VarChar(20)")]
		public string dept
		{
			get
			{
				return this._dept;
			}
			set
			{
				if ((this._dept != value))
				{
					this.OndeptChanging(value);
					this.SendPropertyChanging();
					this._dept = value;
					this.SendPropertyChanged("dept");
					this.OndeptChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_gender", DbType="VarChar(1)")]
		public string gender
		{
			get
			{
				return this._gender;
			}
			set
			{
				if ((this._gender != value))
				{
					this.OngenderChanging(value);
					this.SendPropertyChanging();
					this._gender = value;
					this.SendPropertyChanged("gender");
					this.OngenderChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_alamat", DbType="VarChar(50)")]
		public string alamat
		{
			get
			{
				return this._alamat;
			}
			set
			{
				if ((this._alamat != value))
				{
					this.OnalamatChanging(value);
					this.SendPropertyChanging();
					this._alamat = value;
					this.SendPropertyChanged("alamat");
					this.OnalamatChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
