#include "PhysicsObject.h"
#include <math.h>

PhysicsObject::PhysicsObject(void){
}

PhysicsObject::~PhysicsObject(void){
}

Ogre::Vector3 PhysicsObject::getPosition(){
	return m_position;
}

void PhysicsObject::setPosition(Ogre::Vector3 myPos){
	m_position = myPos;
}
Ogre::Vector3 PhysicsObject::getAccel(){

	return m_accel;
}

void PhysicsObject::setVelocity(Ogre::Vector3 myVelocity){
	m_velocity = myVelocity;
}

Ogre::Vector3 PhysicsObject::getVelocity(){
	return m_velocity;
}


double PhysicsObject::getRadius(){
	return m_radius;
}

bool PhysicsObject::getMove(){
	return m_move;
}

void PhysicsObject::setMove(bool move){
	m_move = move;
}

float PhysicsObject::getAngle(){
	return m_angle;
}

void PhysicsObject::setAngle(float angle){
	m_angle = angle;
}

float PhysicsObject::getPower(){
	return m_power;
}

void PhysicsObject::setPower(float power){
	m_power = power;
}

void PhysicsObject::initialise(Ogre::SceneNode* myNode, double myRadius,Ogre::Vector3 myPosition,Ogre::Vector3 myVelocity, float myAngle, float myPower)
{
	m_objectNode = myNode; //scene node for the model
	setMove(false); //set to true if we want the sphere to move now
	m_radius = myRadius; //set the radius the same as the model
	m_velocity = myVelocity; //set velocity
	m_accel = Ogre::Vector3(0, -9.81, 0);
	m_position = myPosition; //set position
	m_angle = myAngle;
	m_power = myPower;
	m_airtime = 0;
}

void PhysicsObject::update(double elapsedTime){
	//v = u + a*t
	//s = s0 + u*t + 0.5*a*t2

	/*m_position = m_position + (m_velocity*timeChange) + (0.5f * (timeChange * timeChange)); 
	m_velocity = m_velocity + (m_accel * timeChange);
	Ogre::Vector3 pos = m_objectNode->getPosition();*/

	

	m_position = m_position + m_velocity * elapsedTime + 0.5f * m_accel * (elapsedTime * elapsedTime);

	m_velocity  = m_velocity + m_accel * elapsedTime;

	m_objectNode->setPosition(m_position);

	if(m_position.y <= m_radius)
	{	//bounce
		m_velocity.y *=  -0.9f;
		m_velocity.x *= 0.99f;

		if(m_velocity.x < 0.5f && m_velocity.y < 0.5f && m_velocity.y > -0.5f && m_velocity.x > -0.5f)
			m_move = false;
	}
	else
	{
		m_airtime += elapsedTime;
		if(m_position.y > m_maxHeight)
		{	//set new max height
			m_maxHeight = m_position.y;
		}
	}

}

float PhysicsObject::getAirtime() const {
	return m_airtime;
}

float PhysicsObject::getMaxHeight() const {
	return m_maxHeight;
}

//float PhysicsObject::getXDisplacement() const {
//	return m_xDisplacement;
//}

void PhysicsObject::reset() {
	m_airtime = 0;
	m_maxHeight = 0;
}