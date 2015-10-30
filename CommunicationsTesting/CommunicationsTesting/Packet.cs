/* Authors: Dan Wagner, Joy Hauser, Scott Hirsch */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Runtime.Serialization;

namespace CommunicationsTesting
{
    /// <summary>
    /// Packet class for transmitting JSONG objects.
    /// </summary>
    [DataContract]
    internal class Packet
    {
        ///Status of the LED / Headlights
        [DataMember]
        internal bool headlights;

        ///Status of the left driving motor
        [DataMember]
        internal double leftMotor;

        ///Status of the right driving motor
        [DataMember]
        internal double rightMotor;

        ///Status of the angle of the arm
        [DataMember]
        internal double armMotor;

        ///Status of the "holding" mechanism on the arm
        [DataMember]
        internal double armServo;

        ///Status of Y-Axis position of mouse for camera
        [DataMember]
        internal float cameraUpDown;

        ///Status of X-Axis position of mouse for camera
        [DataMember]
        internal float cameraLeftRight;

        ///Status of all five IR sensors
        [DataMember]
        internal float[] irSensors;

        /// <summary>
        /// Creates a new Packet with robot data.
        /// </summary>
        /// <param name="headlights">Headlights status.</param>
        /// <param name="leftMotor">Left driving motor status.</param>
        /// <param name="rightMotor">Right driving motor status.</param>
        /// <param name="armMotor">Arm motor status.</param>
        /// <param name="armServo">Arm servo status.</param>
        /// <param name="cameraUpDown">Camera Y-Axis position.</param>
        /// <param name="cameraLeftRight">Camera X-Axis position.</param>
        /// <param name="irSensors">Status of all five IR Sensors.</param>
        public Packet(bool headlights, double leftMotor, double rightMotor, double armMotor, double armServo, float cameraUpDown, float cameraLeftRight, float[] irSensors)
        {
            this.headlights = headlights;
            this.leftMotor = leftMotor;
            this.rightMotor = rightMotor;
            this.armMotor = armMotor;
            this.armServo = armServo;
            this.cameraUpDown = cameraUpDown;
            this.cameraLeftRight = cameraLeftRight;
            this.irSensors = irSensors;
        }


   
    }
}
