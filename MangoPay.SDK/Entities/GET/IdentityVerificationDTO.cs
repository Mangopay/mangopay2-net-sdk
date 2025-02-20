namespace MangoPay.SDK.Entities.GET
{
    public class IdentityVerificationDTO : EntityBase
    {
	    /// <summary>The URL to which the user is returned after the hosted identity verification session, regardless of the outcome.</summary>
	    public string ReturnUrl { get; set; }
	    
	    /// <summary>The URL to redirect the user to for the hosted identity verification session.</summary>
	    public string HostedUrl { get; set; }

	    /// <summary>
	    /// The status of the identity verification session:
	    /// <para>PENDING – The session is available on the HostedUrl, to which the user must be redirected to complete it.</para>
	    /// <para>VALIDATED – The session was successful.</para>
	    /// <para>REFUSED – The session was refused.</para>
	    /// <para>REVIEW – The session is under manual review by Mangopay.</para>
	    /// <para>OUTDATED – The session is no longer valid (likely due to expired documents used during the session).</para>
	    /// <para>TIMEOUT – The session timed out due to inactivity.</para>
	    /// <para>ERROR – The session was not completed because an error occurred.</para>
	    /// </summary>
	    public string Status { get; set; }
    }
}
