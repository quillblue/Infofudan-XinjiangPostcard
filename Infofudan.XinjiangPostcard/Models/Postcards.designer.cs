﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18449
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Infofudan.XinjiangPostcard.Models
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="PostcardDatabase")]
	public partial class PostcardsDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region 可扩展性方法定义
    partial void OnCreated();
    partial void InsertPostcard(Postcard instance);
    partial void UpdatePostcard(Postcard instance);
    partial void DeletePostcard(Postcard instance);
    partial void InsertPlace(Place instance);
    partial void UpdatePlace(Place instance);
    partial void DeletePlace(Place instance);
    #endregion
		
		public PostcardsDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["PostcardDatabaseConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public PostcardsDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public PostcardsDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public PostcardsDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public PostcardsDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Postcard> Postcard
		{
			get
			{
				return this.GetTable<Postcard>();
			}
		}
		
		public System.Data.Linq.Table<Place> Place
		{
			get
			{
				return this.GetTable<Place>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Postcard")]
	public partial class Postcard : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private System.Nullable<int> _PhotoPlaceId;
		
		private System.Nullable<int> _SenderPlaceId;
		
		private string _SenderName;
		
		private string _Message;
		
		private string _ImageLink;
		
		private EntityRef<Place> _Place;
		
		private EntityRef<Place> _Place1;
		
    #region 可扩展性方法定义
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnPhotoPlaceIdChanging(System.Nullable<int> value);
    partial void OnPhotoPlaceIdChanged();
    partial void OnSenderPlaceIdChanging(System.Nullable<int> value);
    partial void OnSenderPlaceIdChanged();
    partial void OnSenderNameChanging(string value);
    partial void OnSenderNameChanged();
    partial void OnMessageChanging(string value);
    partial void OnMessageChanged();
    partial void OnImageLinkChanging(string value);
    partial void OnImageLinkChanged();
    #endregion
		
		public Postcard()
		{
			this._Place = default(EntityRef<Place>);
			this._Place1 = default(EntityRef<Place>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PhotoPlaceId", DbType="Int")]
		public System.Nullable<int> PhotoPlaceId
		{
			get
			{
				return this._PhotoPlaceId;
			}
			set
			{
				if ((this._PhotoPlaceId != value))
				{
					if (this._Place.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnPhotoPlaceIdChanging(value);
					this.SendPropertyChanging();
					this._PhotoPlaceId = value;
					this.SendPropertyChanged("PhotoPlaceId");
					this.OnPhotoPlaceIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SenderPlaceId", DbType="Int")]
		public System.Nullable<int> SenderPlaceId
		{
			get
			{
				return this._SenderPlaceId;
			}
			set
			{
				if ((this._SenderPlaceId != value))
				{
					if (this._Place1.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnSenderPlaceIdChanging(value);
					this.SendPropertyChanging();
					this._SenderPlaceId = value;
					this.SendPropertyChanged("SenderPlaceId");
					this.OnSenderPlaceIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SenderName", DbType="NVarChar(50)")]
		public string SenderName
		{
			get
			{
				return this._SenderName;
			}
			set
			{
				if ((this._SenderName != value))
				{
					this.OnSenderNameChanging(value);
					this.SendPropertyChanging();
					this._SenderName = value;
					this.SendPropertyChanged("SenderName");
					this.OnSenderNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Message", DbType="NVarChar(MAX)")]
		public string Message
		{
			get
			{
				return this._Message;
			}
			set
			{
				if ((this._Message != value))
				{
					this.OnMessageChanging(value);
					this.SendPropertyChanging();
					this._Message = value;
					this.SendPropertyChanged("Message");
					this.OnMessageChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ImageLink", DbType="NChar(255)")]
		public string ImageLink
		{
			get
			{
				return this._ImageLink;
			}
			set
			{
				if ((this._ImageLink != value))
				{
					this.OnImageLinkChanging(value);
					this.SendPropertyChanging();
					this._ImageLink = value;
					this.SendPropertyChanged("ImageLink");
					this.OnImageLinkChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Place_Postcard", Storage="_Place", ThisKey="PhotoPlaceId", OtherKey="Id", IsForeignKey=true)]
		public Place Place
		{
			get
			{
				return this._Place.Entity;
			}
			set
			{
				Place previousValue = this._Place.Entity;
				if (((previousValue != value) 
							|| (this._Place.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Place.Entity = null;
						previousValue.Postcard.Remove(this);
					}
					this._Place.Entity = value;
					if ((value != null))
					{
						value.Postcard.Add(this);
						this._PhotoPlaceId = value.Id;
					}
					else
					{
						this._PhotoPlaceId = default(Nullable<int>);
					}
					this.SendPropertyChanged("Place");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Place_Postcard1", Storage="_Place1", ThisKey="SenderPlaceId", OtherKey="Id", IsForeignKey=true)]
		public Place Place1
		{
			get
			{
				return this._Place1.Entity;
			}
			set
			{
				Place previousValue = this._Place1.Entity;
				if (((previousValue != value) 
							|| (this._Place1.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Place1.Entity = null;
						previousValue.Postcard1.Remove(this);
					}
					this._Place1.Entity = value;
					if ((value != null))
					{
						value.Postcard1.Add(this);
						this._SenderPlaceId = value.Id;
					}
					else
					{
						this._SenderPlaceId = default(Nullable<int>);
					}
					this.SendPropertyChanged("Place1");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Place")]
	public partial class Place : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _CityName;
		
		private System.Nullable<bool> _IsDomestic;
		
		private double _Lon;
		
		private double _Lat;
		
		private System.Nullable<int> _Type;
		
		private string _Detail;
		
		private System.Nullable<int> _Count;
		
		private EntitySet<Postcard> _Postcard;
		
		private EntitySet<Postcard> _Postcard1;
		
    #region 可扩展性方法定义
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnCityNameChanging(string value);
    partial void OnCityNameChanged();
    partial void OnIsDomesticChanging(System.Nullable<bool> value);
    partial void OnIsDomesticChanged();
    partial void OnLonChanging(double value);
    partial void OnLonChanged();
    partial void OnLatChanging(double value);
    partial void OnLatChanged();
    partial void OnTypeChanging(System.Nullable<int> value);
    partial void OnTypeChanged();
    partial void OnDetailChanging(string value);
    partial void OnDetailChanged();
    partial void OnCountChanging(System.Nullable<int> value);
    partial void OnCountChanged();
    #endregion
		
		public Place()
		{
			this._Postcard = new EntitySet<Postcard>(new Action<Postcard>(this.attach_Postcard), new Action<Postcard>(this.detach_Postcard));
			this._Postcard1 = new EntitySet<Postcard>(new Action<Postcard>(this.attach_Postcard1), new Action<Postcard>(this.detach_Postcard1));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CityName", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
		public string CityName
		{
			get
			{
				return this._CityName;
			}
			set
			{
				if ((this._CityName != value))
				{
					this.OnCityNameChanging(value);
					this.SendPropertyChanging();
					this._CityName = value;
					this.SendPropertyChanged("CityName");
					this.OnCityNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsDomestic", DbType="Bit")]
		public System.Nullable<bool> IsDomestic
		{
			get
			{
				return this._IsDomestic;
			}
			set
			{
				if ((this._IsDomestic != value))
				{
					this.OnIsDomesticChanging(value);
					this.SendPropertyChanging();
					this._IsDomestic = value;
					this.SendPropertyChanged("IsDomestic");
					this.OnIsDomesticChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Lon", DbType="Float NOT NULL")]
		public double Lon
		{
			get
			{
				return this._Lon;
			}
			set
			{
				if ((this._Lon != value))
				{
					this.OnLonChanging(value);
					this.SendPropertyChanging();
					this._Lon = value;
					this.SendPropertyChanged("Lon");
					this.OnLonChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Lat", DbType="Float NOT NULL")]
		public double Lat
		{
			get
			{
				return this._Lat;
			}
			set
			{
				if ((this._Lat != value))
				{
					this.OnLatChanging(value);
					this.SendPropertyChanging();
					this._Lat = value;
					this.SendPropertyChanged("Lat");
					this.OnLatChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Type", DbType="Int")]
		public System.Nullable<int> Type
		{
			get
			{
				return this._Type;
			}
			set
			{
				if ((this._Type != value))
				{
					this.OnTypeChanging(value);
					this.SendPropertyChanging();
					this._Type = value;
					this.SendPropertyChanged("Type");
					this.OnTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Detail", DbType="NChar(10)")]
		public string Detail
		{
			get
			{
				return this._Detail;
			}
			set
			{
				if ((this._Detail != value))
				{
					this.OnDetailChanging(value);
					this.SendPropertyChanging();
					this._Detail = value;
					this.SendPropertyChanged("Detail");
					this.OnDetailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Count", DbType="Int")]
		public System.Nullable<int> Count
		{
			get
			{
				return this._Count;
			}
			set
			{
				if ((this._Count != value))
				{
					this.OnCountChanging(value);
					this.SendPropertyChanging();
					this._Count = value;
					this.SendPropertyChanged("Count");
					this.OnCountChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Place_Postcard", Storage="_Postcard", ThisKey="Id", OtherKey="PhotoPlaceId")]
		public EntitySet<Postcard> Postcard
		{
			get
			{
				return this._Postcard;
			}
			set
			{
				this._Postcard.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Place_Postcard1", Storage="_Postcard1", ThisKey="Id", OtherKey="SenderPlaceId")]
		public EntitySet<Postcard> Postcard1
		{
			get
			{
				return this._Postcard1;
			}
			set
			{
				this._Postcard1.Assign(value);
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
		
		private void attach_Postcard(Postcard entity)
		{
			this.SendPropertyChanging();
			entity.Place = this;
		}
		
		private void detach_Postcard(Postcard entity)
		{
			this.SendPropertyChanging();
			entity.Place = null;
		}
		
		private void attach_Postcard1(Postcard entity)
		{
			this.SendPropertyChanging();
			entity.Place1 = this;
		}
		
		private void detach_Postcard1(Postcard entity)
		{
			this.SendPropertyChanging();
			entity.Place1 = null;
		}
	}
}
#pragma warning restore 1591
