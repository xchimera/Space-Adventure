using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipAnimations : Photon.PunBehaviour, IPunObservable
{

	public ParticleSystem thrustersForward;
	public ParticleSystem thrustersBackward;
	public ParticleSystem thrustersTop;
	public ParticleSystem thrustersBottom;
	public ParticleSystem thrustersLeft;
	public ParticleSystem thrustersRight;
	private GameObject gameData;



	// Update is called once per frame



	private void Start()
	{
		thrustersForward.Stop();
		thrustersBackward.Stop();
		thrustersTop.Stop();
		thrustersBottom.Stop();
		thrustersRight.Stop();
		thrustersLeft.Stop();

	}


	void Update()
	{

		if (!photonView.isMine)
		{
			return;
		}

		//var inside = GameManager.isInsideVehicle;

		//if (inside == true)
		//{
			var verticalThruster = Input.GetAxis("Vertical");
			var HorizontalThruster = Input.GetAxis("Horizontal");
			var lateralThrusters = Input.GetAxis("lift");

			/**
             * Forward / backward
            **/
			if (verticalThruster > 0)
			{
				thrustersForward.Play();
			}
			else if (verticalThruster < 0)
			{
				thrustersBackward.Play();
			}
			else
			{
				thrustersForward.Stop();
				thrustersBackward.Stop();
			}

			/**
             * Up / Down
            **/

			if (lateralThrusters > 0)
			{
				thrustersBottom.Play();
			}
			else if (lateralThrusters < 0)
			{
				thrustersTop.Play();
			}
			else
			{
				thrustersTop.Stop();
				thrustersBottom.Stop();
			}

			/**
             * Sides
            **/
			if (HorizontalThruster > 0)
			{
				thrustersLeft.Play();
			}
			else if (HorizontalThruster < 0)
			{
				thrustersRight.Play();
			}
			else
			{
				thrustersRight.Stop();
				thrustersLeft.Stop();
			}
		//}
	}

	void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting)
		{
			stream.SendNext(thrustersForward.isPlaying);
			stream.SendNext(thrustersBackward.isPlaying);
			stream.SendNext(thrustersTop.isPlaying);
			stream.SendNext(thrustersBottom.isPlaying);
			stream.SendNext(thrustersLeft.isPlaying);
			stream.SendNext(thrustersRight.isPlaying);
		}
		else
		{
			if ((bool)stream.ReceiveNext())
				thrustersForward.Play();
			else
			{
				thrustersForward.Stop();
			}

			if ((bool)stream.ReceiveNext())
				thrustersBackward.Play();
			else
			{
				thrustersBackward.Stop();
			}


			if ((bool)stream.ReceiveNext())
				thrustersTop.Play();
			else
			{
				thrustersTop.Stop();
			}

			if ((bool)stream.ReceiveNext())
				thrustersBottom.Play();
			else
			{
				thrustersBottom.Stop();
			}

			if ((bool)stream.ReceiveNext())
				thrustersLeft.Play();
			else
			{
				thrustersLeft.Stop();
			}

			if ((bool)stream.ReceiveNext())
				thrustersRight.Play();
			else
			{
				thrustersRight.Stop();
			}

		}

	}

}
