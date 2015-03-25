
/** 
* �� �� �� : AccessHelper
* CopyRright (c) 2014-Xinyou Co., Ltd: 
* �ļ���ţ�002 
* �� �� �ˣ�Haden.W 
* ��    �ڣ�2014.8.20
* �� �� �ˣ� 
* ��   �ڣ� 
* ��   ����  ���ݿ������
* �� �� �ţ�0.1
*/

using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Data.OleDb;
using System.Collections;
using System.Windows.Forms;

/// <summary>  
/// AcceHelper ��ժҪ˵��  
/// </summary>  
public class AccessHelper
{
	//���ݿ������ַ���  //��Data Source��ֵ
	public static readonly string conn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=";
	// ���ڻ��������HASH��  
	private static Hashtable parmCache = Hashtable.Synchronized(new Hashtable());
	/// <summary>  
	///  �������ӵ����ݿ��ü������ִ��һ��sql������������ݼ���  
	/// </summary>  
	/// <param name="connectionString">һ����Ч�������ַ���</param>  
	/// <param name="commandText">�洢�������ƻ���sql�������</param>  
	/// <param name="commandParameters">ִ���������ò����ļ���</param>  
	/// <returns>ִ��������Ӱ�������</returns>  
	public static int ExecuteNonQuery(string connectionString, string cmdText, params OleDbParameter[] commandParameters)
	{
		OleDbCommand cmd = new OleDbCommand();
		using (OleDbConnection conn = new OleDbConnection(connectionString))
		{
			PrepareCommand(cmd, conn, null, cmdText, commandParameters);
			int val = cmd.ExecuteNonQuery();
			cmd.Parameters.Clear();
			return val;
		}
	}
	/// <summary>  
	/// �����е����ݿ�����ִ��һ��sql������������ݼ���  
	/// </summary>  
	/// <remarks>  
	///����:    
	///  int result = ExecuteNonQuery(connString, "PublishOrders", new OleDbParameter("@prodid", 24));  
	/// </remarks>  
	/// <param name="conn">һ�����е����ݿ�����</param>  
	/// <param name="commandText">�洢�������ƻ���sql�������</param>  
	/// <param name="commandParameters">ִ���������ò����ļ���</param>  
	/// <returns>ִ��������Ӱ�������</returns>  
	public static int ExecuteNonQuery(OleDbConnection connection, string cmdText, params OleDbParameter[] commandParameters)
	{
		OleDbCommand cmd = new OleDbCommand();
		PrepareCommand(cmd, connection, null, cmdText, commandParameters);
		int val = cmd.ExecuteNonQuery();
		cmd.Parameters.Clear();
		return val;
	}
	/// <summary>  
	///ʹ�����е�SQL����ִ��һ��sql������������ݼ���  
	/// </summary>  
	/// <remarks>  
	///����:    
	///  int result = ExecuteNonQuery(trans, "PublishOrders", new OleDbParameter("@prodid", 24));  
	/// </remarks>  
	/// <param name="trans">һ�����е�����</param>  
	/// <param name="commandText">�洢�������ƻ���sql�������</param>  
	/// <param name="commandParameters">ִ���������ò����ļ���</param>  
	/// <returns>ִ��������Ӱ�������</returns>  
	public static int ExecuteNonQuery(OleDbTransaction trans, string cmdText, params OleDbParameter[] commandParameters)
	{
		OleDbCommand cmd = new OleDbCommand();
		PrepareCommand(cmd, trans.Connection, trans, cmdText, commandParameters);
		int val = cmd.ExecuteNonQuery();
		cmd.Parameters.Clear();
		return val;
	}

	/// <summary>  
	/// ��ִ�е����ݿ�����ִ��һ���������ݼ���sql����  
	/// </summary>  
	/// <remarks>  
	/// ����:    
	///  OleDbDataReader r = ExecuteReader(connString, "PublishOrders", new OleDbParameter("@prodid", 24));  
	/// </remarks>  
	/// <param name="connectionString">һ����Ч�������ַ���</param>  
	/// <param name="commandText">�洢�������ƻ���sql�������</param>  
	/// <param name="commandParameters">ִ���������ò����ļ���</param>  
	/// <returns>��������Ķ�ȡ��</returns>  
	public static OleDbDataReader ExecuteReader(string connectionString, string cmdText, params OleDbParameter[] commandParameters)
	{
		//����һ��SqlCommand����  
		OleDbCommand cmd = new OleDbCommand();
		//����һ��SqlConnection����  
		OleDbConnection conn = new OleDbConnection(connectionString);
		//������������һ��try/catch�ṹִ��sql�ı�����/�洢���̣���Ϊ��������������һ���쳣����Ҫ�ر����ӣ���Ϊû�ж�ȡ�����ڣ�  
		//���commandBehaviour.CloseConnection �Ͳ���ִ��  
		try
		{
			//���� PrepareCommand �������� SqlCommand �������ò���  
			PrepareCommand(cmd, conn, null, cmdText, commandParameters);
			//���� SqlCommand  �� ExecuteReader ����  
			OleDbDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			//�������  
			cmd.Parameters.Clear();
			return reader;
		}
		catch
		{
			//�ر����ӣ��׳��쳣  
			conn.Close();
			throw;
		}
	}

	/// <summary>  
	/// ����һ��DataSet���ݼ�  
	/// </summary>  
	/// <param name="connectionString">һ����Ч�������ַ���</param>  
	/// <param name="cmdText">�洢�������ƻ���sql�������</param>  
	/// <param name="commandParameters">ִ���������ò����ļ���</param>  
	/// <returns>������������ݼ�</returns>  
	public static DataSet ExecuteDataSet(string connectionString, string cmdText, params OleDbParameter[] commandParameters)
	{
		//����һ��SqlCommand���󣬲�������г�ʼ��  
		OleDbCommand cmd = new OleDbCommand();
		using (OleDbConnection conn = new OleDbConnection(connectionString))
		{
			PrepareCommand(cmd, conn, null, cmdText, commandParameters);
			//����SqlDataAdapter�����Լ�DataSet  
			OleDbDataAdapter da = new OleDbDataAdapter(cmd);
			DataSet ds = new DataSet();
			try
			{
				//���ds  
				da.Fill(ds);
				// ���cmd�Ĳ�������   
				cmd.Parameters.Clear();
				//����ds  
				return ds;
			}
			catch
			{
				//�ر����ӣ��׳��쳣  
				conn.Close();
				throw;
			}
		}
	}

	/// <summary>  
	/// ��ָ�������ݿ������ַ���ִ��һ���������һ�����ݼ��ĵ�һ��  
	/// </summary>  
	/// <remarks>  
	///����:    
	///  Object obj = ExecuteScalar(connString, "PublishOrders", new OleDbParameter("@prodid", 24));  
	/// </remarks>  
	///<param name="connectionString">һ����Ч�������ַ���</param>  
	/// <param name="commandText">�洢�������ƻ���sql�������</param>  
	/// <param name="commandParameters">ִ���������ò����ļ���</param>  
	/// <returns>�� Convert.To{Type}������ת��Ϊ��Ҫ�� </returns>  

	public static object ExecuteScalar(string connectionString, string cmdText, params OleDbParameter[] commandParameters)
	{
		OleDbCommand cmd = new OleDbCommand();
		using (OleDbConnection connection = new OleDbConnection(connectionString))
		{
			PrepareCommand(cmd, connection, null, cmdText, commandParameters);
			object val = cmd.ExecuteScalar();
			cmd.Parameters.Clear();
			return val;
		}
	}

	/// <summary>  
	/// ��ָ�������ݿ�����ִ��һ���������һ�����ݼ��ĵ�һ��  
	/// </summary>  
	/// <remarks>  
	/// ����:    
	///  Object obj = ExecuteScalar(connString, "PublishOrders", new OleDbParameter("@prodid", 24));  
	/// </remarks>  
	/// <param name="conn">һ�����ڵ����ݿ�����</param>  
	/// <param name="commandText">�洢�������ƻ���sql�������</param>  
	/// <param name="commandParameters">ִ���������ò����ļ���</param>  
	/// <returns>�� Convert.To{Type}������ת��Ϊ��Ҫ�� </returns>  

	public static object ExecuteScalar(OleDbConnection connection, string cmdText, params OleDbParameter[] commandParameters)
	{
		OleDbCommand cmd = new OleDbCommand();
		PrepareCommand(cmd, connection, null, cmdText, commandParameters);
		object val = cmd.ExecuteScalar();
		cmd.Parameters.Clear();
		return val;
	}

	/// <summary>  
	/// ������������ӵ�����  
	/// </summary>  
	/// <param name="cacheKey">��ӵ�����ı���</param>  
	/// <param name="cmdParms">һ����Ҫ��ӵ������sql��������</param>  

	public static void CacheParameters(string cacheKey, params OleDbParameter[] commandParameters)
	{
		parmCache[cacheKey] = commandParameters;
	}

	/// <summary>  
	/// �һػ����������  
	/// </summary>  
	/// <param name="cacheKey">�����һز����Ĺؼ���</param>  
	/// <returns>����Ĳ�������</returns>  

	public static OleDbParameter[] GetCachedParameters(string cacheKey)
	{
		OleDbParameter[] cachedParms = (OleDbParameter[])parmCache[cacheKey];
		if (cachedParms == null)
			return null;
		OleDbParameter[] clonedParms = new OleDbParameter[cachedParms.Length];
		for (int i = 0, j = cachedParms.Length; i < j; i++)
			clonedParms = (OleDbParameter[])((ICloneable)cachedParms).Clone();
		return clonedParms;
	}

	/// <summary>  
	/// ׼��ִ��һ������  
	/// </summary>  
	/// <param name="cmd">sql����</param>  
	/// <param name="conn">Sql����</param>  
	/// <param name="trans">Sql����</param>  
	/// <param name="cmdText">�����ı�,���磺Select * from Products</param>  
	/// <param name="cmdParms">ִ������Ĳ���</param>  

	private static void PrepareCommand(OleDbCommand cmd, OleDbConnection conn, OleDbTransaction trans, string cmdText, OleDbParameter[] cmdParms)
	{
		//�ж����ӵ�״̬������ǹر�״̬�����  
		if (conn.State != ConnectionState.Open)
	
            conn.Open();
		//cmd���Ը�ֵ  
		cmd.Connection = conn;
		cmd.CommandText = cmdText;
		//�Ƿ���Ҫ�õ�������  
		if (trans != null)
			cmd.Transaction = trans;
		cmd.CommandType = CommandType.Text;
		//���cmd��Ҫ�Ĵ洢���̲���  
		if (cmdParms != null)
		{
			foreach (OleDbParameter parm in cmdParms)
				cmd.Parameters.Add(parm);
		}
	}
}
