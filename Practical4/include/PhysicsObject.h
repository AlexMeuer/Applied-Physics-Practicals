#pragma once
#include "Ogre.h"

class PhysicsObject
{
public:
		PhysicsObject(void); // constructor
		~PhysicsObject(void); // destructor

		//  1st param:	Ogre::SceneNode*  
		//			the node for the graphics model of the physicsObject
		//	2nd param:	double  
		//			for the radius of the physicsObject
		//  3rd param: 	Ogre::Vector3
		//			for the vector position of the physicsObject
		//  4th param:	Ogre::Vector3
		//			for the vector velocity of the physicsObject 
		void initialise(Ogre::SceneNode* , double, Ogre::Vector3, Ogre::Vector3);

		void update(double timeChange);

		Ogre::Vector3 getMaxDisplacement();	//return m_maxDisplacement
		Ogre::Vector3 getPosition();// returns m_position
		Ogre::Vector3 getVelocity();//returns m_velocity
		Ogre::Vector3 getAccel();//return m_accel, the acceleration of the object
		//Ogre::SceneNode* getNode();//returns SceneNode pointer
		double getRadius();  // returns m_radius
		bool getMove();  // returns m_move
		float getTimeMoving();

		void setMaxDisplacement();	//set m_maxDisplacement
		void setAccel(Ogre::Vector3);//sets m_accel
		void setPosition(Ogre::Vector3);// sets m_position
		void setVelocity(Ogre::Vector3);//sets m_velocity
		void setMove(bool);  // sets m_move

private:
		Ogre::Vector3 m_accel;	//acceleration
		Ogre::Vector3 m_position; // position
		Ogre::Vector3 m_maxDisplacement;
		Ogre::Vector3 m_velocity;  // velocity
		double m_radius;			// radius of sphere
		Ogre::SceneNode * m_objectNode;//graphics node of model
		bool m_move;			// moving or not
		float m_timeMoving;
};