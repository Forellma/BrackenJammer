using BepInEx;
using BepInEx.Logging;
using GameNetcodeStuff;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace LC_BrackenJammer.Patches
{
    [HarmonyPatch(typeof(WalkieTalkie))]
    internal class WalkieTalkiePatch
    {

        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        static void jamWalkie()
        {
            
            FlowermanAI brackenRef = RoundManager.FindObjectOfType<FlowermanAI>();
            
            if (brackenRef != null)
            {
                Vector3 b_location = brackenRef.transform.position;
                for (int i = 0; i < WalkieTalkie.allWalkieTalkies.Count; i++) {

                    WalkieTalkie walkie = WalkieTalkie.allWalkieTalkies[i];
                    Vector3 w_location = walkie.GetItemFloorPosition();
                    if ((double)Vector3.Distance(w_location, b_location) <= BrackenJammer.Instance.ConfigManager.JammingDistance)
                    {
                        BrackenJammer.mls.LogInfo("JAMMING");
                        for (int j = 0; j < WalkieTalkie.allWalkieTalkies.Count; j++)
                        {
                            walkie.clientIsHoldingAndSpeakingIntoThis = false;
                            walkie.otherClientIsTransmittingAudios = false;
                        }
                        

                    }
                    else
                    {
                        
                    }
                    
                }
            }
            


        }


    }
}
